using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.ShoeCommands
{
    public class ShoeUpdateCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public ShoeUpdateCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var shoesCollection = this.database.Shoes.ToList();

            foreach (var shoes in shoesCollection)
            {
                this.writer.WriteLine($"Id: {shoes.Id}, Brand: {shoes.Brand.Name}, Model: {shoes.Model.Name}, Color: {shoes.Color.Name}, Type: {shoes.Kind.Name}, Size: {shoes.Size.Name}, Price: {shoes.Price} EUR");
            }

            this.writer.WriteLine("Please provide ID of the item you want to edit.");

            var itemId = int.Parse(this.reader.ReadLine());
            var shoesToUpdate = shoesCollection.First(j => j.Id == itemId);

            this.writer.WriteLine("Enter shoes new price.");

            var newPrice = this.reader.ReadLine();

            shoesToUpdate.Price = decimal.Parse(newPrice);

            this.writer.WriteLine($"The new shoes price is {shoesToUpdate.Price} EUR");

            this.database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
