using NinjasOnlineStore.App.Core.Contracts;
using System;

namespace NinjasOnlineStore.App.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
