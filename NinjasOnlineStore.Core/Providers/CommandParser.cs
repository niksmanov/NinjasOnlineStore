using NinjasOnlineStore.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.App.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            if (commandFactory == null)
            {
                throw new ArgumentNullException("Command factory cannot be null!");
            }

            this.commandFactory = commandFactory;
        }

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
