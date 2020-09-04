using FitnessApp.BL.Controllers;
using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello fucking fat animal");
            Console.WriteLine("My name is FAT_KILLER_SUPER_APP");
            Console.WriteLine("And now you will be track your weight!");

            Console.WriteLine("Enter your Nickname, baby: ");
            var nickname = Console.ReadLine();

            var userController = new UserController(nickname);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender:");
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
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                EnterEating();
            }





            Console.ReadLine();

        }

        private static (Food, double) EnterEating()
        {
            Console.WriteLine("Enter product name");
            var food = Console.ReadLine();
            var weight = ParseToDouble("a weight of portion");

            var calories = ParseToDouble("calories");
            var fats = ParseToDouble("fats");
            var proteins = ParseToDouble("proteins");
            var carbs = ParseToDouble("carbohydrates");

            var product = new Food(food,proteins,fats,carbs,calories);

            return (product, weight);
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
                Console.WriteLine($"Enter {input} :");
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
