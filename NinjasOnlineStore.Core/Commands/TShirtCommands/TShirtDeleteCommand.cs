using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.TShirtCommands
{
    public class TShirtDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public TShirtDeleteCommand(IWriter writer, IReader reader)
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

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var tShirtToDelete = tShirtsCollection.First(j => j.Id == itemId);

            database.TShirts.Remove(tShirtToDelete);

            this.writer.WriteLine($"T-Shirt with ID: {itemId} was successfuly removed!");

            database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
