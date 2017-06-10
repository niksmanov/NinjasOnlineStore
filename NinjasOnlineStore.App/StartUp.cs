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

            var writer = kernel.Get<ConsoleWriter>();

            var type = typeof(ICommand);
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .Select(t => t.Name)
                .Select(c => c.Split(new string[] { "Command" }, StringSplitOptions.RemoveEmptyEntries)[0]).ToList();
            commands.Sort();
            
            writer.WriteLine("These are Ninjas Store commands list!");
            writer.WriteLine("Please use InitializeDatabase first!");
            writer.WriteLine(string.Join(Environment.NewLine, commands));

            engine.Start();
        }
    }
}
