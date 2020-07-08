using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.BL.CustomExceptions
{
    /// <summary>
    /// Custom exception for birthdate
    /// </summary>
    public class BirhDateException : ApplicationException
    {
        public BirhDateException(string message,string paramNameWhoCalledException) : base(message)
        {

        }
    }
}
