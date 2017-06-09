using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.PostgreSQL;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.PostgreSQLCommands
{
    public class ListAllShops : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IPgDatabase database;

        public ListAllShops(IWriter writer, IReader reader, IPgDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var shopsCollection = this.database.Stores.ToList();

            foreach (var shop in shopsCollection)
            {
                this.writer.WriteLine($"Shop {shop.Id}: {shop.Name}");
            }

            return "Command executed successfully!";
        }
    }
}
