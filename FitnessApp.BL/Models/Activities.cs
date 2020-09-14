using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Models
{
    [Serializable]
    public class Activities
    {

        public string ActivityName { get;}
        public double CaloriesPerMin { get; }
        public Activities(string activityName, double caloriesPerMin)
        {
            ActivityName = activityName;
            CaloriesPerMin = caloriesPerMin;
        }
        public override string ToString()
        {
            return $"{ActivityName} - {CaloriesPerMin} cal. ";
        }
    }
}
