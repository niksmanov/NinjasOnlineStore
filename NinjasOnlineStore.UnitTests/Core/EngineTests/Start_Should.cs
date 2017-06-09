using Moq;
using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.UnitTests.Core.EngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void ReadACommandThroughTheReader()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            readerMock.Setup(r => r.ReadLine()).Returns("Exit");

            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var engine = new Engine(readerMock.Object, writerStub.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Once);
        }

        [Test]
        public void TerminateTheProgram_WhenEnteredExitCommand()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("Exit");

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var engine = new Engine(readerStub.Object, writerMock.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void NotThrow_WhenEnteredEmptyCommand()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns("")
                .Returns("Exit");

            var writerMock = new Mock<IWriter>();

            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var engine = new Engine(readerStub.Object, writerMock.Object, parserStub.Object, commandFactoryStub.Object);

            // Act and Assert
            Assert.DoesNotThrow(() => engine.Start());
        }

        [Test]
        public void WriteExceptionErrorMessage_WhenExceptionArises()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine()).Throws(new Exception("Command Not Found!")).Returns("Exit");

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var engine = new Engine(readerStub.Object, writerMock.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("Command Not Found!"))), Times.Once);
        }

        [Test]
        public void ProcessCommand_WhenValidCommandIsEntered()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns("Valid command")
                .Returns("Exit");

            var writerStub = new Mock<IWriter>();
            writerStub.Setup(w => w.WriteLine(It.IsAny<string>()));

            var parserStub = new Mock<ICommandParser>();
            var commandFactoryMock = new Mock<ICommandFactory>();
            commandFactoryMock.Setup(cf => cf.GetCommand(It.IsAny<string>()));

            var engine = new Engine(readerStub.Object, writerStub.Object, parserStub.Object, commandFactoryMock.Object);

            // Act
            engine.Start();

            // Assert
            commandFactoryMock.Verify(cf => cf.GetCommand(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallGetCommandMethodOnCommandsFactory_WhenValidCommandIsEntered()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns("Valid command")
                .Returns("Exit");

            var writerStub = new Mock<IWriter>();
            writerStub.Setup(w => w.WriteLine(It.IsAny<string>()));

            var parserStub = new Mock<ICommandParser>();
            var commandFactoryMock = new Mock<ICommandFactory>();
            commandFactoryMock.Setup(cf => cf.GetCommand(It.IsAny<string>()));

            var engine = new Engine(readerStub.Object, writerStub.Object, parserStub.Object, commandFactoryMock.Object);

            // Act
            engine.Start();

            // Assert
            commandFactoryMock.Verify(cf => cf.GetCommand(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ProcessCommandParameters_WhenValidCommandWithValidParametersIsEntered()
        {
            // Arrange
            string enteredValidCommand = "Valid command";
            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns(enteredValidCommand)
                .Returns("Exit");

            var writerStub = new Mock<IWriter>();

            var parserMock = new Mock<ICommandParser>();
            parserMock.Setup(p => p.ParseParameters(enteredValidCommand));

            var commandFactoryStub = new Mock<ICommandFactory>();

            var engine = new Engine(readerStub.Object, writerStub.Object, parserMock.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            parserMock.Verify(p => p.ParseParameters(enteredValidCommand), Times.Once);
        }

        [Test]
        public void ExecuteTheCommand_WhenValidCommandIsEntered()
        {
            // Arrange
            string enteredValidCommand = "Valid command";

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns(enteredValidCommand)
                .Returns("Exit");

            var writerStub = new Mock<IWriter>();

            var commandParams = new List<string> { "1", "John Doe" };

            var parserStub = new Mock<ICommandParser>();
            parserStub.Setup(p => p.ParseParameters(enteredValidCommand))
                .Returns(commandParams);

            var commandMock = new Mock<ICommand>();
            commandMock.Setup(c => c.Execute(commandParams));

            var commandFactoryStub = new Mock<ICommandFactory>();
            commandFactoryStub.Setup(cf => cf.GetCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var engine = new Engine(readerStub.Object, writerStub.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            commandMock.Verify(c => c.Execute(commandParams), Times.Once);
        }

        [Test]
        public void WriteExecutionResultToTheWriter_WhenValidCommandIsEntered()
        {
            // Arrange
            string enteredValidCommand = "Valid command";
            string executionResult = "Valid command execution result";

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns(enteredValidCommand)
                .Returns("Exit");

            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(executionResult));

            var commandParams = new List<string> { "1", "John Doe" };

            var parserStub = new Mock<ICommandParser>();
            parserStub.Setup(p => p.ParseParameters(enteredValidCommand))
                .Returns(commandParams);

            var commandStub = new Mock<ICommand>();
            commandStub.Setup(c => c.Execute(commandParams))
                .Returns(executionResult);

            var commandFactoryStub = new Mock<ICommandFactory>();
            commandFactoryStub.Setup(cf => cf.GetCommand(It.IsAny<string>())).Returns(commandStub.Object);

            var engine = new Engine(readerStub.Object, writerMock.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(executionResult), Times.Once);
        }
    }
}
