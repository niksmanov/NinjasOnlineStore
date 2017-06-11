using NinjasOnlineStore.App.Core.Providers;
using NUnit.Framework;

namespace NinjasOnlineStore.UnitTests.Core.Providers.CommandParserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfCommandParserClass_WhenInvoked()
        {
            // Arrange
            var expected = "CommandParser";

            // Act
            var result = new CommandParser();

            // Assert
            Assert.AreEqual(expected, result.GetType().Name);
        }

        [Test]
        public void DoesNotThrow_WhenInvoked()
        {
            // Arrange Act & Assert
            Assert.DoesNotThrow(() => new CommandParser());
        }        
    }
}
