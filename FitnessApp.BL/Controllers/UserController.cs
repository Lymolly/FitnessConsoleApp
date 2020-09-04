using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// User's controller.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// App user.
        /// </summary>
        public User CurrentUser { get; }
        public List<User> Users { get; }
        public bool IsNewUser { get; } = false;
        private const string USER_FILE_NAME = "users.dat";


        /// <summary>
        /// Creating new user controller.
        /// </summary>

        public UserController(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new ArgumentNullException("Enter your nickname!", nameof(nickname));
            }
            
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Nickname == nickname);

            if (CurrentUser is null)
            {
                CurrentUser = new User(nickname);
                Users.Add(CurrentUser);
                IsNewUser = true;
                SaveUser();
            }

        }
        public void SetNewUserData(string gender, DateTime birthdate, double weight = 1 ,double height = 1)
        {
            CurrentUser.Gender = new UserGender(gender);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
            SaveUser();
        }
        /// <summary>
        /// Load userses data.
        /// </summary>
        /// <returns>Loads list of users</returns>
        
        public List<User> GetUsersData()
        {
            /// <summary>
            /// BaseController's class method
            /// </summary>
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Save user's data.
        /// </summary>
        private void SaveUser()
        {
            /// <summary>
            /// BaseController's class method
            /// </summary>
            Save(USER_FILE_NAME, Users); 
        }
        
    }
}
