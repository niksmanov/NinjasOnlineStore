using Moq;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.Core.Commands.JacketCommands;
using NinjasOnlineStore.SqlServer;
using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketDeleteCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void DeleteSelectedJacketFromDatabase_WhenInvokedWithValidId()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("0");

            var jacket = new Jacket
            {
                Id = 0,
                Brand = new Brand(),
                Color = new Color(),
                Kind = new Kind(),
                Model = new Model(),
                Size = new Size()
            };

            var data = new List<Jacket> { jacket }.AsQueryable();
            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            sqlDatabaseMock.Setup(db => db.Jackets).Returns(jacketsStub.Object);

            var deleteJacketCommand = new JacketDeleteCommand(writerStub.Object, readerStub.Object, sqlDatabaseMock.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            Assert.AreEqual(0, sqlDatabaseMock.Object.Jackets.ToList().Count);
        }

        [Test]
        public void PromptUserToEnterIdOfJacketToDelete_WhenInvoked()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("0");

            var jacket = new Jacket
            {
                Id = 0,
                Brand = new Brand(),
                Color = new Color(),
                Kind = new Kind(),
                Model = new Model(),
                Size = new Size()
            };

            var data = new List<Jacket> { jacket }.AsQueryable();
            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsStub.Object);

            var deleteJacketCommand = new JacketDeleteCommand(writerMock.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            writerMock.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("ID"))));
        }

        [Test]
        public void ReadIdOfJacketToDelete_WhenInvoked()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            readerMock.Setup(r => r.ReadLine()).Returns("0");

            var jacket = new Jacket
            {
                Id = 0,
                Brand = new Brand(),
                Color = new Color(),
                Kind = new Kind(),
                Model = new Model(),
                Size = new Size()
            };

            var data = new List<Jacket> { jacket }.AsQueryable();
            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsStub.Object);

            var deleteJacketCommand = new JacketDeleteCommand(writerStub.Object, readerMock.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Once);
        }

        [Test]
        public void InformUserThatJacketWasDeleted_WhenInvoked()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("0");

            var jacket = new Jacket
            {
                Id = 0,
                Brand = new Brand(),
                Color = new Color(),
                Kind = new Kind(),
                Model = new Model(),
                Size = new Size()
            };

            var data = new List<Jacket> { jacket }.AsQueryable();
            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseStub = new Mock<ISqlDatabase>();
            sqlDatabaseStub.Setup(db => db.Jackets).Returns(jacketsStub.Object);

            var deleteJacketCommand = new JacketDeleteCommand(writerMock.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            writerMock.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("ID"))));
        }

        [Test]
        public void SaveChangesToDatabaseAfterDeletion_WhenInvokedWithValidId()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("0");

            var jacket = new Jacket
            {
                Id = 0,
                Brand = new Brand(),
                Color = new Color(),
                Kind = new Kind(),
                Model = new Model(),
                Size = new Size()
            };

            var data = new List<Jacket> { jacket }.AsQueryable();
            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            sqlDatabaseMock.Setup(db => db.Jackets).Returns(jacketsStub.Object);
            sqlDatabaseMock.Setup(db => db.SaveChanges());

            var deleteJacketCommand = new JacketDeleteCommand(writerStub.Object, readerStub.Object, sqlDatabaseMock.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            sqlDatabaseMock.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
