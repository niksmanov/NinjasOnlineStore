﻿using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.TShirtCommands
{
    public class TShirtUpdateCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public TShirtUpdateCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var tShirtsCollection = database.TShirts.ToList();

            foreach (var tShirt in tShirtsCollection)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }

            this.writer.WriteLine("Please provide ID of the item you want to edit.");

            var itemId = int.Parse(this.reader.ReadLine());
            var tShirtToUpdate = tShirtsCollection.First(j => j.Id == itemId);

            this.writer.WriteLine("Enter T-Shirt's new price.");

            var newPrice = this.reader.ReadLine();

            tShirtToUpdate.Price = decimal.Parse(newPrice);

            this.writer.WriteLine($"The new T-Shirt price is {tShirtToUpdate.Price} EUR");

            database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
