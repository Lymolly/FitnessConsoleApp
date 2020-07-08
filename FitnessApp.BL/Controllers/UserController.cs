using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// Creating new user controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userFName, string userLName, string nickname,string userGender,
            DateTime birthDate, 
            double weight, double height )
        {
            var gender = new UserGender(userGender); 
            User = new User(userFName, userLName, nickname, birthDate, gender, weight, height);
        }
        /// <summary>
        /// Load user's data.
        /// </summary>
        /// <returns>User's data or empty file</returns>
        public UserController()
        {
            var binFormatter = new BinaryFormatter();
            using (var binFile = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (binFormatter.Deserialize(binFile) is User user)
                {
                    User = user;
                }
                //TODO шо робыть если пользователя для сериализации не нашлось? ??Вернуть форму с предупреждением либо пустой бинарник либо предложить создать нового
            }
        }

        /// <summary>
        /// Save user's data.
        /// </summary>
        public void SaveUser()
        {
            var binFormatter = new BinaryFormatter();
            using (var binFile = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(binFile, User);
            }
        }
        
    }
}
