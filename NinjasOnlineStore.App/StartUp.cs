using NinjasOnlineStore.Core.Contracts;
using Ninject;

namespace NinjasOnlineStore.App
{
    public class StartUp
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjasOnlineStoreModule());

            var engine = kernel.Get<IEngine>();
            var listAllCommands = kernel.Get<ListAllCommands>();

            listAllCommands.CommandsList();
            engine.Start();
        }
    }
}
