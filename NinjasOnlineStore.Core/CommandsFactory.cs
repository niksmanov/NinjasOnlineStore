using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace NinjasOnlineStore.App.Core
{
    public class CommandsFactory : ICommandFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandsFactory(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            TypeInfo type = this.FindCommand(commandName);

            return serviceLocator.GetCommand(type);
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
