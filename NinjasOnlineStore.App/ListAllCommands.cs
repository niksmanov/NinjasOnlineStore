using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Providers;
using Ninject;
using System;
using System.Linq;

namespace NinjasOnlineStore.App
{
    public class ListAllCommands
    {
        public void CommandsList()
        {
            IKernel kernel = new StandardKernel(new NinjasOnlineStoreModule());
            var writer = kernel.Get<ConsoleWriter>();

            var type = typeof(ICommand);
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .Select(t => t.Name)
                .Select(c => c.Split(new string[] { "Command" }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower()).ToList();
            commands.Sort();

            writer.WriteLine("These are Ninjas Store commands list!");
            writer.WriteLine("Please use InitializeDatabase first!");

            foreach (var command in commands)
            {
                writer.WriteLine("- " + command);
                if (command == "jacketsearch")
                {
                    writer.WriteLine("  - listalljackets");
                    writer.WriteLine("  - listjacketsbycolor");
                    writer.WriteLine("  - listjacketsbycolorandsize");
                    writer.WriteLine("  - listjacketsbyprice");
                    writer.WriteLine("  - listjacketsbygender");
                }
                else if (command == "pantssearch")
                {
                    writer.WriteLine("  - listallpants");
                    writer.WriteLine("  - listpantsbycolor");
                    writer.WriteLine("  - listpantsbycolorandsize");
                    writer.WriteLine("  - listpantsbyprice");
                    writer.WriteLine("  - listpantsbygender");
                }
                else if (command == "tshirtsearch")
                {
                    writer.WriteLine("  - listalltshirts");
                    writer.WriteLine("  - listtshirtsbycolor");
                    writer.WriteLine("  - listtshirtsbycolorandsize");
                    writer.WriteLine("  - listtshirtsbyprice");
                    writer.WriteLine("  - listtshirtsbygender");
                }
                else if (command == "swimmingsuitsearch")
                {
                    writer.WriteLine("  - listallswimmingsuits");
                    writer.WriteLine("  - listswimmingsuitsbycolor");
                    writer.WriteLine("  - listswimmingsuitsbycolorandsize");
                    writer.WriteLine("  - listswimmingsuitsbyprice");
                    writer.WriteLine("  - listswimmingsuitsbygender");
                }
                else if (command == "shoesearch")
                {
                    writer.WriteLine("  - listallshoes");
                    writer.WriteLine("  - listshoesbycolor");
                    writer.WriteLine("  - listshoesbycolorandsize");
                    writer.WriteLine("  - listshoesbyprice");
                    writer.WriteLine("  - listshoesbygender");
                }
            }
        }
    }
}
