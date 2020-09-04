using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BL.Models
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    

    [Serializable]
    public class Eating
    {
        public DateTime LastTimeEating { get;}
        public Dictionary<Food, double> FoodList { get; }
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User is unfinded!",nameof(user));
            LastTimeEating = DateTime.UtcNow;
            FoodList = new Dictionary<Food, double>();
        }
        public void AddFood(Food food, double weight)
        {
           var product = FoodList.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                FoodList.Add(food, weight);
            }
            else
            {
                FoodList[product] += weight;
            }
            
        }
        

    }
}
