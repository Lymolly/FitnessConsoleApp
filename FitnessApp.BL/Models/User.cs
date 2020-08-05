using FitnessApp.BL.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Models
{
    [Serializable]
   public  class User
    {
        #region Props and fields
        //private readonly decimal _coins;
        public string FirstName { get;}
        public string LastName { get; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public UserGender Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        //public decimal Coins
        //{
        //    get { return _coins; }
        //}

        public string FName { get; }
        public string LName { get; }
        #endregion

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="fName">First Name.</param>
        /// <param name="lName">Last Name.</param>
        /// <param name="nickname">User's nickname.</param>
        /// <param name="birthdate">User's date of birth.</param>
        /// <param name="gender">User's gender.</param>
        /// <param name="weight">User's weight.</param>
        /// <param name="height">User's height. </param>
        public User(string fName, string lName, string nickname, DateTime birthdate,UserGender gender,double weight,double height)
        {
            #region Checks
            if (string.IsNullOrWhiteSpace(fName))
            {
                throw new ArgumentNullException("Enter your first name!",nameof(fName));
            }
            if (string.IsNullOrWhiteSpace(lName))
            {
                throw new ArgumentNullException("Enter your last name!", nameof(lName));
            }
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new ArgumentNullException("Enter your nickname!", nameof(nickname));
            }
            if (birthdate < DateTime.Parse("01.01.1920") && birthdate >= DateTime.Today)
            {
                throw new BirhDateException("You birth date entered incorrect or null! \n Please try again.", nameof(birthdate));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Enter can't be null", nameof(gender));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be less or equals 0!", nameof(weight));
            }
            if (height <= 40)
            {
                throw new ArgumentException("Height can't be less than 40 cm.", nameof(height));
                
            }
            #endregion
            FName = fName;
            LName = lName;
            Nickname = nickname;
            BirthDate = birthdate;
            Gender = gender;
            Weight = weight;
            Height = height;
        }
        public User(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new ArgumentNullException("Enter your nickname!", nameof(nickname));
            }
            Nickname = nickname;
        }

        public override string ToString()
        {
            return $"Hello, {Nickname}({FirstName} {LastName}) - {Age} y.o.";
        }

    }
}
