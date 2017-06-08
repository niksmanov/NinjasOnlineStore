using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class JacketCreateCommand : ICommand
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

            var jacket = new Jacket();

            jacket.BrandId = int.Parse(brand);
            jacket.ModelId = int.Parse(model);
            jacket.ColorId = int.Parse(color);
            jacket.KindId = int.Parse(type);
            jacket.SizeId = int.Parse(size);
            jacket.Price = Decimal.Parse(price);

            database.Jackets.Add(jacket);

            database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
