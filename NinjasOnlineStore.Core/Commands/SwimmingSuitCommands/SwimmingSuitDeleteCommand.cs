using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.SwimmingSuitCommands
{
    public class SwimmingSuitDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public SwimmingSuitDeleteCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();

            foreach (var swimmingSuits in swimmingSuitsCollection)
            {
                this.writer.WriteLine($"Id: {swimmingSuits.Id}, Brand: {swimmingSuits.Brand.Name}, Model: {swimmingSuits.Model.Name}, Color: {swimmingSuits.Color.Name}, Type: {swimmingSuits.Kind.Name}, Size: {swimmingSuits.Size.Name}, Price: {swimmingSuits.Price} EUR");
            }

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var swimmingSuitsToDelete = swimmingSuitsCollection.First(j => j.Id == itemId);

            this.database.SwimmingSuits.Remove(swimmingSuitsToDelete);

            this.writer.WriteLine($"SwimmingSuits with ID: {itemId} was successfuly removed!");

            this.database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
