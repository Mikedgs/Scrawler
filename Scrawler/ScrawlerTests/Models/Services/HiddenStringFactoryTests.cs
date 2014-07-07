using System;
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
            var cut = new HiddenStringFactory(); // TODO decide on a convention - cut is fine, sut is fine, but have a consistent opinion as a team.

            // Act
            var hiddenString = cut.GenerateHiddenString();

            // Assert
            Assert.That(hiddenString.Length, Is.EqualTo(5));
        }

        [Test]
        public void No_two_strings_are_the_same()
        {
            // Arrange
            throw new NotImplementedException("I hope you're not copying and pasting, Regan.");

            // Act

            // Assert

        }
    }
}
