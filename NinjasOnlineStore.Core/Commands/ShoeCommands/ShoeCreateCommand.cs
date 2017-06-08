using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class ShoeCreateCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var database = JsonImporter.SQLServerDbConnecton();

            var brand = parameters[0];
            var model = parameters[1];
            var color = parameters[2];
            var type = parameters[3];
            var size = parameters[4];
            var price = parameters[5];

            var shoe = new Shoe();

            shoe.BrandId = int.Parse(brand);
            shoe.ModelId = int.Parse(model);
            shoe.ColorId = int.Parse(color);
            shoe.KindId = int.Parse(type);
            shoe.SizeId = int.Parse(size);
            shoe.Price = Decimal.Parse(price);

            database.Shoes.Add(shoe);

            database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
