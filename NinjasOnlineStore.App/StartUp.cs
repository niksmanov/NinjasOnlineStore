using NinjasOnlineStore.App.Core.Commands.Contracts;
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

            var type = typeof(ICommand);
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .Select(t => t.Name)
                .Select(c => c.Split(new string[] { "Command" }, StringSplitOptions.RemoveEmptyEntries)[0]).ToList();
            commands.Sort();

            Console.WriteLine("Commands list!");
            Console.WriteLine("Please use InitializeDatabase first!", Environment.NewLine);
            Console.WriteLine(string.Join(Environment.NewLine, commands));

            engine.Start();
            //To create the database enter the command: InitializeDatabase

            //To create pdf report from SqlServer, PostgreSql and SqLite enter the command: GenerateReport
        }
    }
}
