using NinjasOnlineStore.Core.Contracts;
using NinjasOnlineStore.JSON;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SqLite;
using Ninject;

namespace NinjasOnlineStore.App
{
    public class StartUp
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjasOnlineStoreModule());

            var engine = kernel.Get<IEngine>();
            engine.Start();

            // To run the commented lines below
            // start the app and enter command: InitializeDatabase
            // ---------------------------------------------------

            //string jsonFilePath = "../../../NinjasOnlineStore.JSON/DATA.json";
            //JsonImporter.Import(jsonFilePath);

            //SqLiteImporter.Import();

            //PostgreSQLImporter.Import();
        }
    }
}
