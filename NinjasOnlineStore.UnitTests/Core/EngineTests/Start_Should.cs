using Moq;
using NinjasOnlineStore.App.Core;
using NinjasOnlineStore.App.Core.Contracts;
using NUnit.Framework;
using System;

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
            readerMock.Setup(r => r.ReadLine());

            var writerStub = new Mock<IWriter>();
            var parserStub = new Mock<ICommandParser>();
            var commandFactoryStub = new Mock<ICommandFactory>();
            var engine = new Engine(readerMock.Object, writerStub.Object, parserStub.Object, commandFactoryStub.Object);

            // Act
            engine.Start();

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Once);
        }
    }
}
