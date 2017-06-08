using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.SqlServer;
using NinjasOnlineStore.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands.SwimmingSuitCommands
{
    public class SwimmingSuitCreateCommand : ICommand
    {
        private readonly ISqlDatabase database;

        public SwimmingSuitCreateCommand(ISqlDatabase database)
        {
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
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

            this.database.SwimmingSuits.Add(swimmingSuit);

            this.database.SaveChanges();

            return "Create command executed successfully";
        }
    }
}
