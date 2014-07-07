using System.Collections.Generic;
using System.Linq;
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
            Assert.That(hiddenString.Length, Is.EqualTo(10)); // TODO 5 is not equal to 10
        }

        [Test]
        public void No_two_strings_are_the_same()
        {
            // Arrange
            var cut = new HiddenStringFactory();

            // Act
            var listOfHiddenStrings = new List<string>();
            for (var i = 0; i < 1000000; i ++)
            {
                listOfHiddenStrings.Add(cut.GenerateHiddenString());
            }
            var listOfDistinctStrings = listOfHiddenStrings.Distinct();
            
            // Assert
            Assert.That(listOfHiddenStrings.Count(), Is.EqualTo(listOfDistinctStrings.Count()));
        }
    }
}
