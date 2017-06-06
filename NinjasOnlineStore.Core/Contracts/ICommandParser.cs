using System.Collections.Generic;

namespace NinjasOnlineStore.App.Core.Contracts
{
    public interface ICommandParser
    {
        IList<string> ParseParameters(string fullCommand);
    }
}
