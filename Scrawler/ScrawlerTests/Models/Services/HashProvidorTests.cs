using NUnit.Framework;
using Scrawler.Models.Services;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class HashProvidorTests // TODO spelling
    {
        // TODO additional tests - assert that result is as expected, assert that 2 different inputs have 2 different outputs, test with different length inputs, test with null input, test with empty string input, test with non-alpha string input

        [Test]
        public void that_hashprovidor_returns_a_64_character_hash()// TODO spelling
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
