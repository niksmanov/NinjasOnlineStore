using Moq;
using NinjasOnlineStore.Core.Commands.JacketCommands;
using NinjasOnlineStore.SqlServer;
using NUnit.Framework;
using System;

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketCreateCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfJacketCreateCommandClass_WhenInvoked()
        {
            // Arrange
            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            var expected = "JacketCreateCommand";

            // Act
            var result = new JacketCreateCommand(sqlDatabaseStub.Object);

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void DoesNotThrow_WhenInvoked()
        {
            // Arrange 
            var sqlDatabaseStub = new Mock<ISqlDatabase>();

            //Act & Assert
            Assert.DoesNotThrow(() => new JacketCreateCommand(sqlDatabaseStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedParameterIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JacketCreateCommand(null));
        }
    }
}
