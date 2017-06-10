using Moq;
using NinjasOnlineStore.Core.Commands.JacketCommands;
using NinjasOnlineStore.SqlServer;
using NinjasOnlineStore.SqlServer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketCreateCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void AddNewJacketToDatabase_WhenPassedValidParameters()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var jacketsMock = new Mock<DbSet<Jacket>>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsMock.Object);

            var createJacketCommand = new JacketCreateCommand(sqlDatabaseStub.Object);
            var parameters = new List<string>
            {
                "1", "2", "1", "0", "4", "3"
            };

            // Act
            createJacketCommand.Execute(parameters);

            // Assert
            jacketsMock.Verify(j => j.Add(It.IsAny<Jacket>()), Times.Once);
        }

        [Test]
        public void NotAddNewJacketToDatabase_WhenPassedInvalidParameters()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var jacketsMock = new Mock<DbSet<Jacket>>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsMock.Object);

            var createJacketCommand = new JacketCreateCommand(sqlDatabaseStub.Object);
            var parameters = new List<string>
            {
                "invalidParameter", "2", "1", "0", "4", "3"
            };

            // Act
            Assert.Catch<FormatException>(() => createJacketCommand.Execute(parameters));

            // Assert
            jacketsMock.Verify(j => j.Add(It.IsAny<Jacket>()), Times.Never);
        }

        [Test]
        public void ThrowFormatException_WhenPassedParametersWithInvalidFormat()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var jacketsMock = new Mock<DbSet<Jacket>>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsMock.Object);

            var createJacketCommand = new JacketCreateCommand(sqlDatabaseStub.Object);
            var parameters = new List<string>
            {
                "invalidParameter", "2", "1", "0", "4", "3"
            };

            // Act and Assert
            Assert.Throws<FormatException>(() => createJacketCommand.Execute(parameters));
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_WhenNotAllParametersArePassed()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var jacketsMock = new Mock<DbSet<Jacket>>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsMock.Object);

            var createJacketCommand = new JacketCreateCommand(sqlDatabaseStub.Object);
            var parameters = new List<string>
            {
                "2", "2", "1"
            };

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => createJacketCommand.Execute(parameters));
        }

        [Test]
        public void ReturnMessageForSuccess_WhenPassedValidParameters()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var jacketsMock = new Mock<DbSet<Jacket>>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsMock.Object);

            var createJacketCommand = new JacketCreateCommand(sqlDatabaseStub.Object);
            var parameters = new List<string>
            {
                "1", "2", "1", "0", "4", "3"
            };

            // Act
            string result = createJacketCommand.Execute(parameters);

            // Assert
            StringAssert.Contains("successfully", result);
        }
    }
}
