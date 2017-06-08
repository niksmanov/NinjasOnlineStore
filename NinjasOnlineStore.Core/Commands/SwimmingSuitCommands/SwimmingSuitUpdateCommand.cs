﻿using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.SwimmingSuitCommands
{
    public class SwimmingSuitUpdateCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public SwimmingSuitUpdateCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var swimmingSuitsCollection = database.SwimmingSuits.ToList();

            foreach (var swimmingSuits in swimmingSuitsCollection)
            {
                this.writer.WriteLine($"Id: {swimmingSuits.Id}, Brand: {swimmingSuits.Brand.Name}, Model: {swimmingSuits.Model.Name}, Color: {swimmingSuits.Color.Name}, Type: {swimmingSuits.Kind.Name}, Size: {swimmingSuits.Size.Name}, Price: {swimmingSuits.Price} EUR");
            }

            this.writer.WriteLine("Please provide ID of the item you want to edit.");

            var itemId = int.Parse(this.reader.ReadLine());
            var swimmingSuitsToUpdate = swimmingSuitsCollection.First(j => j.Id == itemId);

            this.writer.WriteLine("Enter swimming suits new price.");

            var newPrice = this.reader.ReadLine();

            swimmingSuitsToUpdate.Price = decimal.Parse(newPrice);

            this.writer.WriteLine($"The new swimming suits price is {swimmingSuitsToUpdate.Price} EUR");

            database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
