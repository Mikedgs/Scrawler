using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Scrawler.Models.Services;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    internal class HiddenStringFactoryTests : UnitTestBase<HiddenStringFactory>
    {
        [Test]
        public void No_two_strings_are_the_same()
        {
            // Arrange

            // Act
            var listOfHiddenStrings = new List<string>();
            for (var i = 0; i < 100000; i ++)
            {
                listOfHiddenStrings.Add(ClassUnderTest.GenerateHiddenString());
            }
            var listOfDistinctStrings = listOfHiddenStrings.Distinct();

            // Assert
            Assert.That(listOfHiddenStrings.Count(), Is.EqualTo(listOfDistinctStrings.Count()));
        }

        [Test]
        public void that_GenerateHiddenString_returns_a_10_character_string()
        {
            // Arrange

            // Act
            var hiddenString = ClassUnderTest.GenerateHiddenString();

            // Assert
            Assert.That(hiddenString.Length, Is.EqualTo(10));
        }
    }
}