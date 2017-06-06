using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.Core.Contracts;
using Ninject;
using System;

namespace NinjasOnlineStore.App
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(Type commandType)
        {
            return (ICommand)this.kernel.Get(commandType);
        }
    }
}
