using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SQLite;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.SqLiteCommands
{
    public class ListAllCities : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly SQLiteDbContext database;

        public ListAllCities(IWriter writer, IReader reader, SQLiteDbContext database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var citiesCollection = this.database.Cities.ToList();

            foreach (var city in citiesCollection)
            {
                this.writer.WriteLine($"In {city.Name} we have {city.Shops.Count()} shops!");
            }

            return "Command executed successfully!";
        }
    }
}
