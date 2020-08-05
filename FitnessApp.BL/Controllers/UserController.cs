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
    public class UserController
    {
        /// <summary>
        /// App user.
        /// </summary>
        public User CurrentUser { get; }
        public List<User> Users { get; }
        public bool IsNewUser { get; } = false;


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
            var binFormatter = new BinaryFormatter();
            using (var binFile = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                ///<summary>
                ///Костыль!
                ///    |
                ///    |
                ///   \ /
                ///    |
                /// </summary>
                if (binFile.Length == 0)
                {
                    return new List<User>();
                }
                if (binFormatter.Deserialize(binFile) is List<User> users)
                {
                    return users;
                }
                else
                {                   
                   return new List<User>();
                }
            }
        }

        /// <summary>
        /// Save user's data.
        /// </summary>
        private void SaveUser()
        {
            var binFormatter = new BinaryFormatter();
            using (var binFile = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(binFile, Users);
            }
        }
        
    }
}
