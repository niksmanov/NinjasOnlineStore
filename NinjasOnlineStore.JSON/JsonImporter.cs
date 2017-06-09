using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using NinjasOnlineStore.JSON.JsonAdditions;
using NinjasOnlineStore.JSON.JsonModels;
using NinjasOnlineStore.SqlServer;
using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Contracts;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace NinjasOnlineStore.JSON
{
    public class JsonImporter : IJsonImporter
    {
        private readonly ISqlDatabase database;
        private readonly StringBuilder builder;
        public JsonImporter(ISqlDatabase database, StringBuilder builder)
        {
            this.database = database;
            this.builder = builder;
        }

        private void UploadInDatabase(ISqlDatabase database, DbSet dbCollection,
            IJsonAddition jsonAddition = null, IEnumerable<IJsonObject> jsonObjectsCollection = null)
        {

            var jsonObjectName = string.Empty;
            if (jsonAddition == null)
            {
                jsonObjectName = jsonObjectsCollection.GetType().GetGenericArguments()[0].Name.Split(new string[] { "Json" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else if (jsonObjectsCollection == null)
            {
                jsonObjectName = jsonAddition.GetType().Name.Split(new string[] { "Json" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            IAddition addition = null;
            IObject model = null;

            switch (jsonObjectName)
            {
                case "Brand": addition = new Brand(); break;
                case "Color": addition = new Color(); break;
                case "Model": addition = new Model(); break;
                case "Size": addition = new Size(); break;
                case "Kind": addition = new Kind(); break;
                case "Jacket": model = new Jacket(); break;
                case "Pants": model = new Pants(); break;
                case "Shoe": model = new Shoe(); break;
                case "SwimmingSuit": model = new SwimmingSuit(); break;
                case "TShirt": model = new TShirt(); break;
                default: throw new ArgumentException("The provided class is not from acceptable classes!");
            }

            if (addition != null)
            {
                foreach (var itemToAdd in jsonAddition.Names)
                {
                    addition.Name = itemToAdd;
                    dbCollection.Add(addition);
                    this.database.SaveChanges();
                }
            }
            if (model != null)
            {
                foreach (var itemToAdd in jsonObjectsCollection)
                {
                    model.Price = itemToAdd.Price;
                    model.SizeId = itemToAdd.SizeId;
                    model.ColorId = itemToAdd.ColorId;
                    model.BrandId = itemToAdd.BrandId;
                    model.KindId = itemToAdd.KindId;
                    model.ModelId = itemToAdd.ModelId;
                    dbCollection.Add(model);
                    this.database.SaveChanges();
                }
            }
        }

        public string Import(string jsonFilePath)
        {
            string fileContent = File.ReadAllText(jsonFilePath);

            //Additions
            var jsonBrand = JsonConvert.DeserializeObject<JsonBrand>(fileContent);
            var jsonColor = JsonConvert.DeserializeObject<JsonColor>(fileContent);
            var jsonModel = JsonConvert.DeserializeObject<JsonModel>(fileContent);
            var jsonSize = JsonConvert.DeserializeObject<JsonSize>(fileContent);
            var jsonKind = JsonConvert.DeserializeObject<JsonKind>(fileContent);

            //Models
            var jsonModelsCollection = JsonConvert.DeserializeObject<JsonModelsCollection>(fileContent);

            if (this.database.Brands.FirstOrDefault() == null)
            {
                this.builder.AppendLine("Adding additional data...");
                UploadInDatabase(this.database, this.database.Brands, jsonBrand, null);
                UploadInDatabase(this.database, this.database.Colors, jsonColor, null);
                UploadInDatabase(this.database, this.database.Models, jsonModel, null);
                UploadInDatabase(this.database, this.database.Sizes, jsonSize, null);
                UploadInDatabase(this.database, this.database.Kinds, jsonKind, null);
                this.builder.AppendLine("Additional data added successfully!");
            }

            if (this.database.Jackets.FirstOrDefault() == null)
            {
                this.builder.AppendLine("Adding models data...");
                UploadInDatabase(this.database, this.database.Jackets, null, jsonModelsCollection.Jackets);
                UploadInDatabase(this.database, this.database.Pants, null, jsonModelsCollection.Pants);
                UploadInDatabase(this.database, this.database.Shoes, null, jsonModelsCollection.Shoes);
                UploadInDatabase(this.database, this.database.SwimmingSuits, null, jsonModelsCollection.SwimmingSuits);
                UploadInDatabase(this.database, this.database.TShirts, null, jsonModelsCollection.TShirts);
                this.builder.AppendLine("Models data added successfully!");
            }

            return this.builder.ToString();
        }
    }
}
