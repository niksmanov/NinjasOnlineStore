using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.PantsCommands
{
    public class PantsDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public PantsDeleteCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var pantsCollection = this.database.Pants.ToList();

            foreach (var pants in pantsCollection)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var pantsToDelete = pantsCollection.First(j => j.Id == itemId);

            this.database.Pants.Remove(pantsToDelete);

            this.writer.WriteLine($"Pants with ID: {itemId} was successfully removed!");

            this.database.SaveChanges();
                
            return "Command executed successfully";
        }
    }
}
