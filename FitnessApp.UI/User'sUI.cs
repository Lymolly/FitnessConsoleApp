using FitnessApp.BL.Controllers;
using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-en");
            var resourceManager = new ResourceManager("FitnessApp.UI.Languages.Messages en-en", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterNickname", culture));


            var nickname = Console.ReadLine();

            var userController = new UserController(nickname);
            var eatingFoodController = new FoodEatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender",culture));
                var gender = Console.ReadLine();
                var birhtDate = ParseDateTime();
                var weight = ParseToDouble("weight");
                var height = ParseToDouble("height");


                userController.SetNewUserData(gender, birhtDate, weight, height);
            }
            else
            {
                Console.WriteLine(userController.CurrentUser);
            }
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("If you want to enter eating push - E");
            //Console.WriteLine("If you wanna check all food history - press R");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingFoodController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingFoodController.Eating.FoodList)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value} gr.");
                }
            }  

                Console.WriteLine($"Last eating date : {eatingFoodController.Eating.LastTimeEating}");
                Console.ReadLine();

        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.Write("Enter product name : ");
            var food = Console.ReadLine();
            var weight = ParseToDouble("a weight of portion");

            var calories = ParseToDouble("calories");
            var fats = ParseToDouble("fats");
            var proteins = ParseToDouble("proteins");
            var carbs = ParseToDouble("carbohydrates");

            var product = new Food(food,proteins,fats,carbs,calories);

            return (Food: product,Weight: weight);
        }
        #region Parse helpful funcs
        private static DateTime ParseDateTime()
        {
            DateTime birhtDate;
            while (true)
            {
                Console.WriteLine("Enter your birth date (Month.Day.Year):");
                if (DateTime.TryParse(Console.ReadLine(), out birhtDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct date please!");
                }
            }

            return birhtDate;
        }

        private static double ParseToDouble(string input)
        {
            while (true)
            {
                Console.Write($"Enter {input} : ");
                if (double.TryParse(Console.ReadLine() , out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Enter correct number!");
                }
            }
        }
        #endregion
    }
}
