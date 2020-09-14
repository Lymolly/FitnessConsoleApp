using FitnessApp.BL.Models;
using FitnessApp.BL.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BL.Controllers
{
    public class ExerciseActivityController : BaseController
    {
        private readonly User user;
        public List<Exercise> Exercises;
        public List<Activities> Activities;
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        public ExerciseActivityController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User unfinded!",nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

       

        public void AddActivity(Activities activity,DateTime start,DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.ActivityName == activity.ActivityName);
            
            if (act is null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);              
            }
            else
            {

                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }
            SaveExercises();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        private List<Activities> GetAllActivities()
        {
            return Load<List<Activities>>(ACTIVITIES_FILE_NAME) ?? new List<Activities>();
        }
        private void SaveExercises()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
