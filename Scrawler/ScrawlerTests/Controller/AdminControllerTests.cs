using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
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

            sessionMock.Setup(x => x.ValidateInput(It.IsAny<Admin>())).Returns(true);
            adminDbMock.Setup(x => x.GetAdmin(It.IsAny<Admin>())).Returns(new Admin());
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));
            //Act
            ClassUnderTest.Login(new Admin());

            //Assert
            adminDbMock.Verify(x => x.GetAdmin(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.ValidateInput(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
        }
    }

    [TestFixture]
    internal class AdminControllerTests_create_user_post_action_scenario : UnitTestBase<AdminController>
    {
        [Test]
        public void Create_user_post_action_returns_a_RedirectToRouteResult()
        {
            //Arrange
            var sessionMock = GetMock<ISessionProxy>();
            var adminDbMock = GetMock<IAdminRepository>();
            sessionMock.Setup(x => x.IsLoggedIn).Returns(true);
            adminDbMock.Setup(x => x.SaveUser(It.IsAny<Admin>()));
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));

            //Act
            var result = ClassUnderTest.CreateUser(new Admin());
            //Assert
            sessionMock.VerifyGet(x => x.IsLoggedIn, Times.Exactly(1));
            adminDbMock.Verify(x => x.SaveUser(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
            Assert.That(result, Is.TypeOf(typeof (RedirectToRouteResult)));

        }
    }
    [TestFixture]
    class AdminControllerTests_create_user_get_action_scenario : UnitTestBase<AdminController>
    {
        [Test]
        public void Create_user_get_action_returns_a_ViewResult()
        {
            //Arrange
            var sessionMock = GetMock<ISessionProxy>();
            sessionMock.Setup(x => x.IsLoggedIn).Returns(true);

            //Act
            var result = ClassUnderTest.CreateUser();
            //Assert
            sessionMock.VerifyGet(x => x.IsLoggedIn, Times.Exactly(1));
            Assert.IsInstanceOf(typeof(ViewResult), result);

        }
    }
}
