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

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketUpdateCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void PromptUserToEnterIdOfJacketToUpdate_WhenInvoked()
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

            var deleteJacketCommand = new JacketUpdateCommand(writerMock.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            writerMock.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("ID"))));
        }

        [Test]
        public void PromptUserToEnterNewPriceOfJacketToUpdate_WhenInvoked()
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

            var deleteJacketCommand = new JacketUpdateCommand(writerMock.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            writerMock.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("new price"))));
        }

        [Test]
        public void ReadIdAndNewPriceOfJacketToUpdate_WhenInvoked()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            readerMock.SetupSequence(r => r.ReadLine())
                .Returns("0")
                .Returns("20.5");

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

            var deleteJacketCommand = new JacketUpdateCommand(writerStub.Object, readerMock.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Exactly(2));
        }

        [Test]
        public void ReturnAListOfAllJackets_WhenInvoked()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(r => r.ReadLine())
                .Returns("0")
                .Returns("20.5");

            var data = new List<Jacket>
            {
                new Jacket
                {
                    Id = 0,
                    Brand = new Brand(),
                    Color = new Color(),
                    Kind = new Kind(),
                    Model = new Model(),
                    Size = new Size()
                },
                new Jacket
                {
                    Id = 1,
                    Brand = new Brand(),
                    Color = new Color(),
                    Kind = new Kind(),
                    Model = new Model(),
                    Size = new Size()
                }
            }.AsQueryable();

            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(data.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(data.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            sqlDatabaseMock.Setup(db => db.Jackets).Returns(jacketsStub.Object);

            var searchJacketCommand = new JacketUpdateCommand(writerMock.Object, readerStub.Object, sqlDatabaseMock.Object);

            // Act
            searchJacketCommand.Execute(null);

            // Assert
            writerMock.Verify(
                w => w.WriteLine(It.Is<string>(str => str.Contains("Id"))), Times.Exactly(2));
        }

        [Test]
        public void SaveTheUpdatedJacketToDatabase_WhenInvoked()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();

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
            sqlDatabaseStub.Setup(db => db.SaveChanges());

            var deleteJacketCommand = new JacketUpdateCommand(writerMock.Object, readerStub.Object, sqlDatabaseStub.Object);

            // Act
            deleteJacketCommand.Execute(null);

            // Assert
            sqlDatabaseStub.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
