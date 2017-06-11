using Moq;
using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.Core.Contracts;
using NinjasOnlineStore.UnitTests.Core.CommandsFactoryTests.Fakes;
using NUnit.Framework;
using System;

namespace NinjasOnlineStore.UnitTests.Core.CommandsFactoryTests
{
    [TestFixture]
    public class GetCommand_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedCommandDoesNotExist()
        {
            // Arrange
            var commandsLocatorStub = new Mock<IServiceLocator>();
            var factory = new CommandsFactory(commandsLocatorStub.Object);
            var nonexistingCommand = "Nonexisting Command";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.GetCommand(nonexistingCommand));
        }

        [Test]
        public void ThrowWithNotFoundMessage_WhenPassedCommandDoesNotExist()
        {
            // Arrange
            var commandsLocatorStub = new Mock<IServiceLocator>();
            var factory = new CommandsFactory(commandsLocatorStub.Object);
            var nonexistingCommand = "Nonexisting Command";

            // Act
            var ex = Assert.Catch<ArgumentException>(() => factory.GetCommand(nonexistingCommand));

            // Assert
            StringAssert.Contains("not found", ex.Message);
        }

        [Test]
        public void ReturnICommandObject_WhenPassedValidCommand()
        {
            // Arrange
            var commandStub = new Mock<FakeCommand>();
            var commandsLocatorStub = new Mock<IServiceLocator>();
            commandsLocatorStub.Setup(cl => cl.GetCommand(It.IsAny<Type>())).Returns(commandStub.Object);

            var factory = new FakeCommandsFactory(commandsLocatorStub.Object);
            var expected = "FakeCommandProxy";

            // Act
            var result = factory.GetCommand("FakeCommand");

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void CreateCommandThroughTheServiceLocator_WhenPassedValidCommand()
        {
            // Arrange
            var commandStub = new Mock<FakeCommand>();
            var commandsLocatorMock = new Mock<IServiceLocator>();
            commandsLocatorMock.Setup(cl => cl.GetCommand(It.IsAny<Type>()));

            var factory = new FakeCommandsFactory(commandsLocatorMock.Object);

            // Act
            var result = factory.GetCommand("FakeCommand");

            // Assert
            commandsLocatorMock.Verify(cl => cl.GetCommand(It.IsAny<Type>()), Times.Once);
        }
    }
}
