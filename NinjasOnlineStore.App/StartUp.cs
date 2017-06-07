using NinjasOnlineStore.Core.Contracts;
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

            //To create the database enter the command: InitializeDatabase

            //To create pdf report from SqlServer, PostgreSql and SqLite enter the command: GenerateReport
        }
    }
}
