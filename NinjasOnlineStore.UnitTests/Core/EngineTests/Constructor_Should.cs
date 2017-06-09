using Moq;
using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.App.Core.Contracts;
using NUnit.Framework;
using System;

namespace NinjasOnlineStore.UnitTests.Core.EngineTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfEngineClass_WhenAllPassedParametersAreValid()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var expected = "Engine";

            // Act
            var result = new Engine(readerStub.Object, writerStub.Object, parserStub.Object, commandFactoryStub.Object);

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void DoesNotThrow_WhenAllPassedParametersAreValid()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();

            // Act & Assert
            Assert.DoesNotThrow(() => new Engine(readerStub.Object, writerStub.Object, parserStub.Object, commandFactoryStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedReaderIsNull()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writerStub.Object, parserStub.Object, commandFactoryStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedWriterIsNull()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerStub.Object, null, parserStub.Object, commandFactoryStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedParserIsNull()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var writerStub = new Mock<IWriter>();
            var commandFactoryStub = new Mock<ICommandFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerStub.Object, writerStub.Object, null, commandFactoryStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedCommandFactoryIsNull()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(readerStub.Object, writerStub.Object, parserStub.Object, null));
        }
    }
}
