using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessApp.BL.Controllers
{
    public class FoodEatingController : BaseController
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        /// <summary>
        /// 2 const with file name
        /// </summary>
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";

        public FoodEatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User unfined", nameof(user));
            Foods = GetAllFood();
            Eating = GetEating();
        }
            
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product is null)
            {
                Foods.Add(food);
                Eating.AddFood(food, weight);
                SaveFood();
            }
            else
            {
                Eating.AddFood(product, weight);
                SaveFood();
            }
        }
                     #region Get and Save Food Methods
        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFood()
        {
            /// <summary>
            /// BaseController's class method
            /// </summary>
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>(); 
            
        }
        private void SaveFood()
        {
            /// <summary>
            /// BaseController's class method
            /// </summary>
            Save(FOOD_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
        #endregion
    }
}
