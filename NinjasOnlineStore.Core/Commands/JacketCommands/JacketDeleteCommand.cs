using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class JacketDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public JacketDeleteCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null");
            }

            if (reader == null)
            {
                throw new ArgumentNullException("Reader cannot be null");
            }

            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null");
            }

            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var jacketsCollection = this.database.Jackets.ToList();

            foreach (var jacket in jacketsCollection)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var jacketToDelete = jacketsCollection.First(j => j.Id == itemId);

            this.database.Jackets.Remove(jacketToDelete);

            this.writer.WriteLine($"Jacket with ID: {itemId} was successfully removed!");

            this.database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
