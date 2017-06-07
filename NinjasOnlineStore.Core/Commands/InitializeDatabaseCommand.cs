using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SqLite;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands
{
    public class InitializeDatabaseCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            // TODO: Extract jsonFilePath as parameter
            const string jsonFilePath = "../../../NinjasOnlineStore.JSON/DATA.json";

            // TODO: Inject IWriter to replace Console
            Console.WriteLine("Parsing JSON and initializing SqlServer...");

            // TODO: Inject reporter and make Import method non static
            JsonImporter.Import(jsonFilePath);

            Console.WriteLine("Initializing SqLite...");

            // TODO: Split this command into three separate commands for each importer
            SqLiteImporter.Import();

            Console.WriteLine("Initializing Postgres...");
            PostgreSQLImporter.Import();

            return "Initialization succeeded!";
        }
    }
}
