using Moq;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.App.Core.Providers;
using NUnit.Framework;
using System.Collections.Generic;

namespace NinjasOnlineStore.UnitTests.Core.Providers.CommandParserTests
{
    [TestFixture]
    public class ParseParameters_Should
    {
        [TestCase("")]
        [TestCase("Command")]
        [TestCase("Command 0 1 parameter")]
        public void NotThrow_WhenInvokedWithAnyStringParameter(string param)
        {
            // Arrange
            var parser = new CommandParser();

            // Act & Assert
            Assert.DoesNotThrow(() => parser.ParseParameters(param));
        }

        [Test]
        public void NotThrow_WhenInvokedWithNullParameter()
        {
            // Arrange
            var parser = new CommandParser();

            // Act & Assert
            Assert.DoesNotThrow(() => parser.ParseParameters(null));
        }

        [Test]
        public void ReturnNull_WhenInvokedWithCommandThatHasNoParameters()
        {
            // Arrange
            var parser = new CommandParser();

            // Act
            var result = parser.ParseParameters(null);

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void ReturnListOfStrings_WhenInvokedWithCommandThatHasParameters()
        {
            // Arrange
            var parser = new CommandParser();
            var validCommand = "ComamndName 1 JohnDoe parameter";
            var expected = new List<string> { "1", "JohnDoe", "parameter" };

            // Act
            var result = parser.ParseParameters(validCommand);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
