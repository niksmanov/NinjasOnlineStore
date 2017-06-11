using Moq;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.Core.Commands.JacketCommands;
using NinjasOnlineStore.SqlServer;
using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NinjasOnlineStore.UnitTests.Core.Commands.JacketCommands.JacketSearchCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenEnteredUnsupportedParameter()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            var searchJacketCommand = new JacketSearchCommand(writerStub.Object, readerStub.Object, sqlDatabaseMock.Object);
            var invalidParams = new List<string> { "UnsupportedParameter" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => searchJacketCommand.Execute(invalidParams));
        }

        [Test]
        public void ThrowWithNotSupportedMessage_WhenEnteredUnsupportedParameter()
        {
            // Arrange
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();
            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            var searchJacketCommand = new JacketSearchCommand(writerStub.Object, readerStub.Object, sqlDatabaseMock.Object);
            var invalidParams = new List<string> { "UnsupportedParameter" };

            // Act
            var result = Assert.Catch<ArgumentException>(() => searchJacketCommand.Execute(invalidParams));

            // Assert
            StringAssert.Contains("not supported", result.Message);
        }

        [Test]
        public void ReturnAListOfAllJackets_WhenInvokedWithParameterListAllJackets()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var readerStub = new Mock<IReader>();

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

            var searchJacketCommand = new JacketSearchCommand(writerMock.Object, readerStub.Object, sqlDatabaseMock.Object);
            var validParams = new List<string> { "ListAllJackets" };

            // Act
            searchJacketCommand.Execute(validParams);

            // Assert
            writerMock.Verify(
                w => w.WriteLine(It.Is<string>(str => str.Contains("Id"))), Times.Exactly(2));
        }

        [Test]
        public void ReturnAListOfAllJacketsBySpecifiedColor_WhenInvokedWithParameterListJacketsByColor()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(w => w.WriteLine(It.IsAny<string>()));

            var readerStub = new Mock<IReader>();
            readerStub.Setup(r => r.ReadLine()).Returns("Blue");

            var jacketsData = new List<Jacket>
            {
                new Jacket
                {
                    Id = 0,
                    Brand = new Brand(),
                    Color = new Color { Name = "Blue"},
                    Kind = new Kind(),
                    Model = new Model(),
                    Size = new Size()
                },
                new Jacket
                {
                    Id = 1,
                    Brand = new Brand(),
                    Color = new Color { Name = "Black"},
                    Kind = new Kind(),
                    Model = new Model(),
                    Size = new Size()
                }
            }.AsQueryable();

            var jacketsStub = new Mock<DbSet<Jacket>>();
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Provider).Returns(jacketsData.Provider);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.Expression).Returns(jacketsData.Expression);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.ElementType).Returns(jacketsData.ElementType);
            jacketsStub.As<IQueryable<Jacket>>().Setup(m => m.GetEnumerator()).Returns(jacketsData.GetEnumerator());

            var colorData = new List<Color>
            {
                new Color { Name = "Blue" },
                new Color { Name = "Black" }
            }.AsQueryable();

            var colorsStub = new Mock<DbSet<Color>>();
            colorsStub.As<IQueryable<Color>>().Setup(m => m.Provider).Returns(colorData.Provider);
            colorsStub.As<IQueryable<Color>>().Setup(m => m.Expression).Returns(colorData.Expression);
            colorsStub.As<IQueryable<Color>>().Setup(m => m.ElementType).Returns(colorData.ElementType);
            colorsStub.As<IQueryable<Color>>().Setup(m => m.GetEnumerator()).Returns(colorData.GetEnumerator());

            var sqlDatabaseMock = new Mock<ISqlDatabase>();
            sqlDatabaseMock.Setup(db => db.Jackets).Returns(jacketsStub.Object);
            sqlDatabaseMock.Setup(db => db.Colors).Returns(colorsStub.Object);

            var searchJacketCommand = new JacketSearchCommand(writerMock.Object, readerStub.Object, sqlDatabaseMock.Object);
            var validParams = new List<string> { "ListJacketsByColor" };

            // Act
            searchJacketCommand.Execute(validParams);

            // Assert
            writerMock.Verify(
                w => w.WriteLine(It.Is<string>(str => str.Contains("Id"))), Times.Exactly(1));
        }
    }
}
