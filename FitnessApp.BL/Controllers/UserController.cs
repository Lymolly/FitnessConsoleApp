using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace FitnessApp.BL.Controllers
{
    public class UserController
    {
        public User User { get; }
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("User is'nt found",nameof(user));
        }
        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
