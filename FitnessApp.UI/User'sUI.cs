using FitnessApp.BL.Controllers;
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


            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            DateTime birhtDate;
            while (true)
            {
                Console.WriteLine("Enter your birth date (dd.MM.yyyy):");
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
    }
}
