using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.Core.Contracts;
using System;
using System.Reflection;

namespace NinjasOnlineStore.UnitTests.Core.CommandsFactoryTests.Fakes
{
    public class FakeCommandsFactory : CommandsFactory
    {
        public FakeCommandsFactory(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {                
        }
        
        protected override TypeInfo FindCommand(string commandName)
        {
            Type type = new FakeCommand().GetType();
            return (TypeInfo)type;
        }
    }
}
