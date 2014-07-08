using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Scrawler.Models.Services;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class HashProviderTests : UnitTestBase<HashProvider>
    {
        [Test]
        public void that_hashprovider_returns_a_64_character_hash()
        {
            // Arrange
            // Act
            var result = ClassUnderTest.GetSHA("password");

            // Assert
            Assert.That(result.Length, Is.EqualTo(64)); 
        }

        [Test]
        public void that_hashprovider_with_two_different_length_inputs_returns_same_length_password()
        {
            // Arrange
            // Act
            var result = ClassUnderTest.GetSHA("password");
            var nextResult = ClassUnderTest.GetSHA("nextPassword");

            // Assert
            Assert.That(result.Length, Is.EqualTo(nextResult.Length));
        }

        [Test]
        public void that_hashprovider_with_two_different_inputs_produces_different_results()
        {
            // Arrange

            // Act
            var result = ClassUnderTest.GetSHA("password");
            var nextResult = ClassUnderTest.GetSHA("nextPassword");

            // Assert
            Assert.That(result, Is.Not.EqualTo(nextResult));
        }

        [Test]
        public void that_hashprovider_with_non_alphanumeric_characters_returns_valid_password()
        {
            // Arrange

            // Act
            var result = ClassUnderTest.GetSHA("';.,/*-/");

            // Assert
            Assert.That(result.Length, Is.EqualTo(64));
        }

        [Test]
        public void that_hashprovider_creates_unique_hashes()
        {
            // Arrange
            var factory = new HiddenStringFactory();
            var listOfInputs = new List<string>();
            for (var i = 0; i < 100; i++)
            {
                listOfInputs.Add(factory.GenerateHiddenString());
            }

            // Act
            var listOfResults = listOfInputs.Select(item => ClassUnderTest.GetSHA(item)).ToList();

            // Assert
            Assert.That(listOfResults.Distinct().Count(), Is.EqualTo(listOfResults.Count));


        }

        [Test]
        public void that_GetSHA_cant_handle_nulls()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => ClassUnderTest.GetSHA(null));
        }

        [Test]
        public void that_GetSHA_cant_handle_empty_string()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => ClassUnderTest.GetSHA(string.Empty));
        }   
    }
}
