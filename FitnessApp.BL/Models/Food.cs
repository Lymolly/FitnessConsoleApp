using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Models
{
    [Serializable]
    public class Food
    {
        public string Name { get;}

        /// <summary>
        /// Белки за 100 грамм
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры за 100 грамм
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы за 100 грамм
        /// </summary>
        public double Carbohydrates { get;}
        /// <summary>
        /// Калории за 100 грамм
        /// </summary>
        public double Calories { get; }


        //public Food(string name) : this(name, 0, 0, 0, 0)
        //{
        //}
        public Food(string name,double proteins, double fats, double carbohydrates, double calories)
        {
            #region Checks
            if (Proteins < 0)
            {
                throw new ArgumentNullException("Proteins can't be less than 0", nameof(Proteins));
            }
            if (Fats < 0)
            {
                throw new ArgumentNullException("Fats can't be less than 0", nameof(Fats));
            }
            if (Carbohydrates < 0)
            {
                throw new ArgumentNullException("Carbohydrates can't be less than 0", nameof(Carbohydrates));
            }
            if (Calories < 0)
            {
                throw new ArgumentNullException("Calories can't be less than 0", nameof(Calories));
            }
            #endregion
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
