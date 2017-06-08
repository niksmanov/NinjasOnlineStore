using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.PantsCommands
{
    public class PantsUpdateCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public PantsUpdateCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var pantsCollection = database.Pants.ToList();

            foreach (var pants in pantsCollection)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }

            this.writer.WriteLine("Please provide ID of the item you want to edit.");

            var itemId = int.Parse(this.reader.ReadLine());
            var pantsToUpdate = pantsCollection.First(j => j.Id == itemId);

            this.writer.WriteLine("Enter pants's new price.");

            var newPrice = this.reader.ReadLine();

            pantsToUpdate.Price = decimal.Parse(newPrice);

            this.writer.WriteLine($"The new pants price is {pantsToUpdate.Price} EUR");

            database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
