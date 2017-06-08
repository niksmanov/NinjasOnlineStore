﻿using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.ShoeCommands
{
    public class ShoeDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public ShoeDeleteCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var shoesCollection = this.database.Shoes.ToList();

            foreach (var shoe in shoesCollection)
            {
                this.writer.WriteLine($"Id: {shoe.Id}, Brand: {shoe.Brand.Name}, Model: {shoe.Model.Name}, Color: {shoe.Color.Name}, Type: {shoe.Kind.Name}, Size: {shoe.Size.Name}, Price: {shoe.Price} EUR");
            }

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var shoesToDelete = shoesCollection.First(j => j.Id == itemId);

            this.database.Shoes.Remove(shoesToDelete);

            this.writer.WriteLine($"Shoes with ID: {itemId} was successfuly removed!");

            this.database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
