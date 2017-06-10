using NinjasOnlineStore.App.Core.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.UnitTests.Core.CommandsFactoryTests.Fakes
{
    public class FakeCommand : ICommand
    {
        public virtual string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
        
    }
}
