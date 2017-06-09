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
        private readonly IJsonImporter jsonImporter;
        private readonly ISqLiteImporter sqLiteImporter;
        private readonly IPostgreSQLImporter postgreImporter;
        public InitializeDatabaseCommand(IWriter writer, IJsonImporter jsonImporter, ISqLiteImporter sqLiteImporter, PostgreSQLImporter postgreImporter)
        {
            this.writer = writer;
            this.jsonImporter = jsonImporter;
            this.sqLiteImporter = sqLiteImporter;
            this.postgreImporter = postgreImporter;
        }
        public string Execute(IList<string> parameters)
        {
            const string jsonFilePath = "../../../NinjasOnlineStore.JSON/DATA.json";

            this.writer.WriteLine("Parsing JSON and initializing SqlServer...");
            var jsonImporter = this.jsonImporter.Import(jsonFilePath);
            this.writer.Write(jsonImporter);

            this.writer.WriteLine("Initializing SqLite...");
            var sqLiteImporter = this.sqLiteImporter.Import();
            this.writer.Write(sqLiteImporter);

            this.writer.WriteLine("Initializing Postgres...");
            var postgreImporter = this.postgreImporter.Import();
            this.writer.Write(postgreImporter);

            return "Initialization succeeded!";
        }
    }
}
