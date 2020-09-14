using FitnessApp.BL.Controllers;
using FitnessApp.BL.Models;
using FitnessApp.BL.Models.Activity;
using System;
using System.Globalization;
using System.Resources;


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
            #region Controllers Initialization
            var userController = new UserController(nickname);
            var eatingFoodController = new FoodEatingController(userController.CurrentUser);
            var ExActivityController = new ExerciseActivityController(userController.CurrentUser);
#endregion

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender",culture));
                var gender = Console.ReadLine();
                var birhtDate = ParseDateTime("birth date");
                var weight = ParseToDouble("weight");
                var height = ParseToDouble("height");


                userController.SetNewUserData(gender, birhtDate, weight, height);
            }
            else
            {
                Console.WriteLine(userController.CurrentUser);
            }

            #region WhatToDo
            while (true)
            {
                Console.WriteLine(resourceManager.GetString("WhatToDo", culture));
                Console.WriteLine(resourceManager.GetString("EnterEating", culture));
                Console.WriteLine(resourceManager.GetString("EnterExercise", culture));
                Console.WriteLine(resourceManager.GetString("SeeInformation"),culture);
                Console.WriteLine(resourceManager.GetString("Exit", culture));
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingFoodController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingFoodController.Eating.FoodList)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value} gr.");
                        }
                        Console.WriteLine(resourceManager.GetString($"LastEatingDate : {eatingFoodController.Eating.LastTimeEating}", culture));
                        Console.ReadLine();

                        break;

                    case ConsoleKey.A:
                        var activities = StartExercises();
                        ExActivityController.AddActivity(activities.Activity, activities.Begin, activities.End);
                        foreach (var item in ExActivityController.Exercises)
                        {
                            Console.WriteLine($"\t {item.Activity.ActivityName}, for : {item.ExFinish - item.ExStart}, " +
                                $"\t From {item.ExStart.ToShortTimeString()} to {item.ExFinish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.WriteLine(userController.CurrentUser);
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(1);
                        break;
                }
            }
            #endregion
        }

        private static (DateTime Begin, DateTime End, Activities Activity) StartExercises()
        {
            Console.WriteLine("Enter exercise name: ");
            var exerciseName = Console.ReadLine();
            var energy = ParseToDouble("consumption energy per minute");

            var activity = new Activities(exerciseName, energy);

            var begin = ParseDateTime("activity time begin");
            var end = ParseDateTime("end time of activity");

            return (begin, end, activity);
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
        private static DateTime ParseDateTime(string input)
        {
            DateTime dateTime;
           
            while (true)
            {
                if (input.Contains("activity time begin")|| input.Contains("end time of activity"))
                {
                    Console.Write($"Enter {input} (HH:mm): ");
                    if (DateTime.TryParse(Console.ReadLine(),out dateTime))
                    {
                        dateTime.ToShortTimeString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Enter the correct {input} please!");
                    }
                }
                else
                {
                    Console.Write($"Enter {input} (DD.mm.yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out dateTime))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Enter the correct {input} please!");
                    }
                }
                
            }
            return dateTime;
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
