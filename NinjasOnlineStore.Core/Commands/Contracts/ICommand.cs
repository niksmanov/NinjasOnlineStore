using System.Collections.Generic;

namespace NinjasOnlineStore.App.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
