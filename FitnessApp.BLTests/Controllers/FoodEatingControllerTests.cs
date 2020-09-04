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
    public class FoodEatingControllerTests
    {
        [TestMethod()]
        public void AddFoodMethodTest()
        {

            //Arrange
            var nickname = Guid.NewGuid().ToString();
            var foodname = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserController(nickname);
            var eatingController = new FoodEatingController(userController.CurrentUser);
            var food = new Food(foodname, rnd.Next(1, 200),rnd.Next(1,200),rnd.Next(1,200),rnd.Next(1,350));
            //Act
            eatingController.Add(food, 100);
            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.FoodList.Keys.First(f => f == food).Name);
        }
    }
}