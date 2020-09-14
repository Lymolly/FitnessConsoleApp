using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Models.Activity
{
    [Serializable]
    public class Exercise
    {
        public DateTime ExStart { get;}
        public DateTime ExFinish { get;}
        public Activities Activity { get;}
        public User User { get; }
        public Exercise(DateTime exStart, DateTime exFinish, Activities activity, User user)
        {
            //Checks
            //
            //Checks
            ExStart = exStart;
            ExFinish = exFinish;
            Activity = activity;
            User = user;
        }
    }
}
