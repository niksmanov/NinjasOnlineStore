using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.App.Core.Providers;
using NinjasOnlineStore.Core.Contracts;
using NinjasOnlineStore.Core.Providers;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SqLite;
using NinjasOnlineStore.SQLite;
using NinjasOnlineStore.SqlServer;
using Ninject.Modules;

namespace NinjasOnlineStore.App
{
    public class NinjasOnlineStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>();
            this.Bind<IPdfReportWriter>().To<PdfReportWriter>().InSingletonScope();
            
            this.Bind<ICommandFactory>().To<CommandsFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<ISqlDatabase>().To<SqlServerDbContext>();
            this.Bind<IPgDatabase>().To<PostgreSQLDbContext>();
            this.Bind<ISqLiteDatabase>().To<SQLiteDbContext>();

            this.Bind<ISqLiteImporter>().To<SqLiteImporter>().InSingletonScope();
            this.Bind<IPostgreSQLImporter>().To<PostgreSQLImporter>().InSingletonScope();
            this.Bind<IJsonImporter>().To<JsonImporter>().InSingletonScope();
        }
    }
}
