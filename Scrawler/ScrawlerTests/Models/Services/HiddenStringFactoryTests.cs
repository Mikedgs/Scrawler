using NUnit.Framework;
using Scrawler.Models.Services;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class HiddenStringFactoryTests
    {
        [Test]
        public void that_GenerateHiddenString_returns_a_5_character_string()
        {
            // Arrange
            var cut = new HiddenStringFactory();

            // Act
            var hiddenString = cut.GenerateHiddenString();

            // Assert
            Assert.That(hiddenString.Length, Is.EqualTo(5));
        }
    }
}
