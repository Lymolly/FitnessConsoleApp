using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.Models
{
    /// <summary>
    /// Gender entity
    /// </summary>
    public class UserGender
    {
        /// <summary>
        /// Gender name property
        /// </summary>
        public string GenderName { get; }

        /// <summary>
        /// Check gender
        /// </summary>
        /// <param name="gender"></param>
        public UserGender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Gender can't be null!", nameof(gender));
            }
        }
        public override string ToString()
        {
            return GenderName;
        }

    }
}
