using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    internal class AdminControllerTests_login_scenario : UnitTestBase<AdminController>
    {
        [Test]
        public void Login_action_hits_every_method_within_it_only_once()
        {
            //Arrange
            var adminDbMock = GetMock<IAdminRepository>();
            var sessionMock = GetMock<ISessionProxy>();

            adminDbMock.Setup(x => x.GetAdmin(It.IsAny<Admin>())).Returns(new Admin());
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));
            //Act
            ClassUnderTest.Login(new Admin());

            //Assert
            adminDbMock.Verify(x => x.GetAdmin(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
        }
    }

    [TestFixture]
    internal class AdminControllerTests_create_user_post_action_scenario : UnitTestBase<AdminController>
    {
        [Test]
        public void Create_user_post_action_hits_all_methods_inside_once()
        {
            //Arrange
            var sessionMock = GetMock<ISessionProxy>();
            var adminDbMock = GetMock<IAdminRepository>();
            sessionMock.Setup(x => x.IsLoggedIn).Returns(true);
            adminDbMock.Setup(x => x.SaveAdmin(It.IsAny<Admin>()));
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));

            //Act
            ClassUnderTest.CreateUser(new Admin());

            //Assert
            adminDbMock.Verify(x => x.SaveAdmin(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
        }
    }
}