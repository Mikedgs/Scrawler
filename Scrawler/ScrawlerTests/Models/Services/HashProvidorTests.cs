using NUnit.Framework;
using Scrawler.Models.Services;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class HashProvidorTests
    {
        [Test]
        public void that_hashprovidor_returns_a_64_character_hash()
        {
            // Arrange
            var cut = new HashProvider();

            // Act
            var result = cut.GetMd5Hash("password");

            // Assert
            Assert.That(result.Length, Is.EqualTo(64));
        }
    }
}
