using NinjasOnlineStore.App.Core.Commands.Contracts;

namespace NinjasOnlineStore.App.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string fullCommand);
    }
}
