using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessApp.BL.Models;
using System.Linq;

namespace FitnessApp.BL.Controllers.Tests
{
    [TestClass()]
    public class ExerciseActivityControllerTests
    {
      

        [TestMethod()]
        public void AddActivityTest()
        {
            //Arrange
            var nickname = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();  
            var rnd = new Random();

            var userController = new UserController(nickname);
            var exeActController = new ExerciseActivityController(userController.CurrentUser);
            var activity = new Activities(activityName, rnd.Next(5, 50));

            //Act
            exeActController.AddActivity(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activityName,exeActController.Activities.First().ActivityName);
            
        }
    }
}