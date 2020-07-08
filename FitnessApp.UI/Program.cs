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

            Console.WriteLine("Enter your First Name, baby: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter your Last Name, baby: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter your Nickname, baby: ");
            var nickname = Console.ReadLine();

            Console.WriteLine("Enter your Gender: ");
            var gender = Console.ReadLine();
            
            Console.WriteLine("Enter the date birth: ");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter your weight: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(firstName,lastName,nickname,gender,birthDate,weight,height);
            userController.SaveUser();
            Console.ReadLine();








        }
    }
}
