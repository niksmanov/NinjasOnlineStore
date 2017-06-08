using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class JacketDeleteCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public JacketDeleteCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var jacketsCollection = database.Jackets.ToList();

            foreach (var jacket in jacketsCollection)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }

            this.writer.Write("Please provide ID of the item you want to remove: ");

            var itemId = int.Parse(this.reader.ReadLine());
            var jacketToDelete = jacketsCollection.First(j => j.Id == itemId);

            database.Jackets.Remove(jacketToDelete);

            //var update = this.reader.ReadLine().Split(' ');
            //var updateArr = update.ToArray().Select(int.Parse);

            //jacketToUpdate.BrandId = updateArr.ElementAt(0);
            //jacketToUpdate.ModelId = updateArr.ElementAt(1);
            //jacketToUpdate.ColorId = updateArr.ElementAt(2);
            //jacketToUpdate.KindId = updateArr.ElementAt(3);
            //jacketToUpdate.SizeId = updateArr.ElementAt(4);
            //jacketToUpdate.Price = updateArr.ElementAt(5);

            this.writer.WriteLine($"Jacket with ID: {itemId} was successfuly removed!");

            database.SaveChanges();

            return "Command executed successfully";
        }
    }
}
