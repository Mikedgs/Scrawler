using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    class AdminControllerTests : UnitTestBase<AdminController>
    {
        [Test]
        public void Login_action_hits_every_method_within_it_only_once()
        {
            //Arrange
            var adminDbMock = GetMock<IAdminDb>();
            var sessionMock = GetMock<ISessionProxy>();

            sessionMock.Setup(x => x.ValidateInput(It.IsAny<Admin>())).Returns(true);
            adminDbMock.Setup(x => x.Validate(It.IsAny<Admin>())).Returns(new Admin());
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));
            //Act
            ClassUnderTest.Login(new Admin());

            //Assert
            adminDbMock.Verify(x => x.Validate(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.ValidateInput(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
        }

        [Test]
        public void Create_user_post_action_returns_a_RedirectToRouteResult()
        {
            //Arrange
            var sessionMock = GetMock<ISessionProxy>();
            var adminDbMock = GetMock<IAdminDb>();
            sessionMock.Setup(x => x.CheckIfLoggedIn()).Returns(true);
            adminDbMock.Setup(x => x.SaveUser(It.IsAny<Admin>()));
            sessionMock.Setup(x => x.AddAdminToSession(It.IsAny<Admin>()));

            //Act
            var result = ClassUnderTest.CreateUser(new Admin());
            //Assert
            sessionMock.Verify(x => x.CheckIfLoggedIn(), Times.Exactly(1));
            adminDbMock.Verify(x => x.SaveUser(It.IsAny<Admin>()), Times.Exactly(1));
            sessionMock.Verify(x => x.AddAdminToSession(It.IsAny<Admin>()), Times.Exactly(1));
            Assert.That(result, Is.TypeOf(typeof (RedirectToRouteResult)));

        }

        [Test]
        public void Create_user_get_action_returns_a_ViewResult()
        {
            //Arrange
            var sessionMock = GetMock<ISessionProxy>();
            sessionMock.Setup(x => x.CheckIfLoggedIn()).Returns(true);

            //Act
            var result = ClassUnderTest.CreateUser();
            //Assert
            sessionMock.Verify(x => x.CheckIfLoggedIn(), Times.Exactly(1));
            Assert.IsInstanceOf(typeof(ViewResult), result);

        }
    }
}
