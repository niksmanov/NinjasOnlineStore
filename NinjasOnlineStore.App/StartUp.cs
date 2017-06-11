using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Providers;
using NinjasOnlineStore.Core.Contracts;
using Ninject;
using System;
using System.Linq;

namespace NinjasOnlineStore.App
{
    public class StartUp
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjasOnlineStoreModule());
            var engine = kernel.Get<IEngine>();

            ListAllCommands list = new ListAllCommands();
            list.CommandsList();

            engine.Start();
        }
    }
}
