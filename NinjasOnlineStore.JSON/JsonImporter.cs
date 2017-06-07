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

namespace NinjasOnlineStore.JSON
{
    public class JsonImporter
    {
        public static SqlServerDbContext SQLServerDbConnecton()
        {
            var database = new SqlServerDbContext();
            return database;
        }

        private static void UploadInDatabase(SqlServerDbContext database, DbSet dbCollection,
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
                    database.SaveChanges();
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
                    database.SaveChanges();
                }
            }
        }

        public static void Import(string jsonFilePath)
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

            var database = SQLServerDbConnecton();

            if (database.Brands.FirstOrDefault() == null)
            {
                Console.WriteLine("Adding additional data...");
                UploadInDatabase(database, database.Brands, jsonBrand, null);
                UploadInDatabase(database, database.Colors, jsonColor, null);
                UploadInDatabase(database, database.Models, jsonModel, null);
                UploadInDatabase(database, database.Sizes, jsonSize, null);
                UploadInDatabase(database, database.Kinds, jsonKind, null);
                Console.WriteLine("Additional data added successfully!");
            }

            if (database.Jackets.FirstOrDefault() == null)
            {
                Console.WriteLine("Adding models data...");
                UploadInDatabase(database, database.Jackets, null, jsonModelsCollection.Jackets);
                UploadInDatabase(database, database.Pants, null, jsonModelsCollection.Pants);
                UploadInDatabase(database, database.Shoes, null, jsonModelsCollection.Shoes);
                UploadInDatabase(database, database.SwimmingSuits, null, jsonModelsCollection.SwimmingSuits);
                UploadInDatabase(database, database.TShirts, null, jsonModelsCollection.TShirts);
                Console.WriteLine("Models data added successfully!");
            }
        }
    }
}
