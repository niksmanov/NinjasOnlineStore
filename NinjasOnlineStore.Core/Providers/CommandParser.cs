using NinjasOnlineStore.App.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.App.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        public IList<string> ParseParameters(string fullCommand)
        {
            if (fullCommand == null)
            {
                fullCommand = string.Empty;
            }

            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }
    }
}
