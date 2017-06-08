using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.PantsCommands
{
    public class PantsDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public PantsDeleteCommand(IWriter writer, IReader reader)
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

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var pantsToDelete = pantsCollection.First(j => j.Id == itemId);

            database.Pants.Remove(pantsToDelete);

            this.writer.WriteLine($"Pants with ID: {itemId} was successfuly removed!");

            database.SaveChanges();
                
            return "Command executed successfully";
        }
    }
}
