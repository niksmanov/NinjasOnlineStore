using NinjasOnlineStore.App.Core.Commands.Contracts;
using System;

namespace NinjasOnlineStore.Core.Contracts
{
    public interface IServiceLocator
    {
        ICommand GetCommand(Type commandType);
    }
}
