using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.TShirtCommands
{
    public class TShirtCreateCommand : ICommand
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

            var tShirt = new TShirt();

            tShirt.BrandId = int.Parse(brand);
            tShirt.ModelId = int.Parse(model);
            tShirt.ColorId = int.Parse(color);
            tShirt.KindId = int.Parse(type);
            tShirt.SizeId = int.Parse(size);
            tShirt.Price = Decimal.Parse(price);

            database.TShirts.Add(tShirt);

            database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
