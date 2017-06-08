using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.PantsCommands
{
    public class PantsCreateCommand : ICommand
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

            var pants = new Pants();

            pants.BrandId = int.Parse(brand);
            pants.ModelId = int.Parse(model);
            pants.ColorId = int.Parse(color);
            pants.KindId = int.Parse(type);
            pants.SizeId = int.Parse(size);
            pants.Price = Decimal.Parse(price);

            database.Pants.Add(pants);

            database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
