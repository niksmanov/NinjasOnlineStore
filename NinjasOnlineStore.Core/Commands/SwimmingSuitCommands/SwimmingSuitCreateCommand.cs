using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.SwimmingSuitCommands
{
    public class SwimmingSuitCreateCommand : ICommand
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

            var swimmingSuit = new SwimmingSuit();

            swimmingSuit.BrandId = int.Parse(brand);
            swimmingSuit.ModelId = int.Parse(model);
            swimmingSuit.ColorId = int.Parse(color);
            swimmingSuit.KindId = int.Parse(type);
            swimmingSuit.SizeId = int.Parse(size);
            swimmingSuit.Price = Decimal.Parse(price);

            database.SwimmingSuits.Add(swimmingSuit);

            database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
