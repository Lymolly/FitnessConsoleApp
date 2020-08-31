using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = new Guid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 75;
            var height = 180;
            var gender = "male";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Nickname);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.GenderName);
        }

        [TestMethod()]
        public void GetUsersDataTest()
        {
            //var userName = new Guid().ToString();
            //var controller = new UserController(userName);
            //Assert.AreEqual(userName, controller.CurrentUser.Nickname);
        }
    }
}