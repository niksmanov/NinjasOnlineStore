﻿using Moq;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.Core.Commands.JacketCommands;
using NinjasOnlineStore.SqlServer;
using NUnit.Framework;
using System;

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketUpdateCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfJacketUpdateCommandClass_WhenInvoked()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var expected = "JacketUpdateCommand";

            // Act
            var result = new JacketUpdateCommand(writerStub.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void NotThrow_WhenInvoked()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            var sqlDatabaseStub = new Mock<ISqlDatabase>();

            //Act & Assert
            Assert.DoesNotThrow(
                () => new JacketUpdateCommand(writerStub.Object, readerStub.Object, sqlDatabaseStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedWriterIsNull()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var sqlDatabaseStub = new Mock<ISqlDatabase>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new JacketUpdateCommand(null, readerStub.Object, sqlDatabaseStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedReaderIsNull()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var sqlDatabaseStub = new Mock<ISqlDatabase>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new JacketUpdateCommand(writerStub.Object, null, sqlDatabaseStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedDatabaseIsNull()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new JacketUpdateCommand(writerStub.Object, readerStub.Object, null));
        }
    }
}
