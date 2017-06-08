using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SqLite;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.Core.Commands
{
    public class InitializeDatabaseCommand : ICommand
    {
        private readonly IWriter writer;
        public InitializeDatabaseCommand(IWriter writer)
        {
            this.writer = writer;
        }
        public string Execute(IList<string> parameters)
        {
            // TODO: Extract jsonFilePath as parameter
            const string jsonFilePath = "../../../NinjasOnlineStore.JSON/DATA.json";

        
            this.writer.WriteLine("Parsing JSON and initializing SqlServer...");

            // TODO: Inject reporter and make Import method non static
            JsonImporter.Import(jsonFilePath);

            this.writer.WriteLine("Initializing SqLite...");

            // TODO: Split this command into three separate commands for each importer
            SqLiteImporter.Import();

            this.writer.WriteLine("Initializing Postgres...");
            PostgreSQLImporter.Import();

            return "Initialization succeeded!";
        }
    }
}
