﻿using Moq;
using NUnit.Framework;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    internal class AdminRepositoryTests_SaveUser_scenario : UnitTestBase<AdminRepository>
    {
        [Test]
        public void SaveUser_calls_hashing_method_and_adds_user_to_database()
        {
            // Arrange
            Mock<IHashProvider> hashMock = GetMock<IHashProvider>();
            Mock<IRepository<Admin>> repoMock = GetMock<IRepository<Admin>>();
            var admin = new Admin {UserName = "admin", Password = "password"};

            // Act
            ClassUnderTest.SaveAdmin(admin);

            // Assert
            hashMock.Verify(x => x.GetSha("password"), Times.Once);
            repoMock.Verify(x => x.Add(admin), Times.Once);
        }
    }

    internal class AdminRepositoryTests_GetAdmin_scenario : UnitTestBase<AdminRepository>
    {
        [Test]
        public void GetAdmin_calls_hashing_method()
        {
            // Arrange
            Mock<IHashProvider> hashMock = GetMock<IHashProvider>();
            Mock<IRepository<Admin>> repoMock = GetMock<IRepository<Admin>>();
            var admin = new Admin {UserName = "admin", Password = "password"};

            // Act
            ClassUnderTest.SaveAdmin(admin);

            // Assert
            hashMock.Verify(x => x.GetSha(It.IsAny<string>()), Times.Once);
            repoMock.Verify(x => x.Add(It.IsAny<Admin>()), Times.Once);
        }

        [Test]
        public void SaveUser_hashes_password_before_saving_to_database()
        {
            // Arrange
            Mock<IHashProvider> hashMock = GetMock<IHashProvider>();
            const string hashedPassword = "newpassword";
            hashMock.Setup(x => x.GetSha(It.IsAny<string>())).Returns(hashedPassword);
            var admin = new Admin {UserName = "admin", Password = "password"};

            // Act
            ClassUnderTest.SaveAdmin(admin);

            // Assert
            Assert.AreEqual(admin.Password, hashedPassword);
        }
    }
}