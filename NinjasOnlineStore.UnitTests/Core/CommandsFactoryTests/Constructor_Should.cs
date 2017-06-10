using Moq;
using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.Core.Contracts;
using NUnit.Framework;
using System;

namespace NinjasOnlineStore.UnitTests.Core.CommandsFactoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfCommandsFactoryClass_WhenAllPassedParametersAreValid()
        {
            // Arrange
            var commandsLocatorStub = new Mock<IServiceLocator>();
            var expected = "CommandsFactory";

            // Act
            var result = new CommandsFactory(commandsLocatorStub.Object);

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void DoesNotThrow_WhenAllPassedParametersAreValid()
        {
            // Arrange
            var commandsLocatorStub = new Mock<IServiceLocator>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CommandsFactory(commandsLocatorStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedServiceLocatorIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommandsFactory(null));
        }
    }
}
