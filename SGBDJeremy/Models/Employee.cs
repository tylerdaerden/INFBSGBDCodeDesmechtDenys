using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Employee
    {

        private int _employee_ID;
        private string _userName;
        private string _role;
        private bool _isAvalaible;
        private string _passwordHash;
        private string _salt;


        public int EmployeeID 
        { 
            get => _employee_ID;
            set => _employee_ID = value;
        }
        public string UserName 
        { 
            get => _userName;
            set => _userName = value;
        }

        public string Role
        {
            get => _role;
            set => _role = value;
        }
        public bool Avalaible
        {
            get => _isAvalaible;
            set => _isAvalaible = value;
        }
        public string PasswordHash
        {
            get => _passwordHash; 
            set => _passwordHash = value;
        }

        //Pasword Salting = a random piece of data is added to the password before it runs through the hashing algorithm, making it unique and harder to crack. When using both hashing and salting, even if two users choose the same password, salting adds random characters to each password when the users enter them.
        public string Salt
        {
            get => _salt; 
            set => _salt = value;
        }

        //methods

        /// <summary>
        /// Check if Selected role is valid
        /// non sensitive case and accept a underscore
        /// no numbers accepted 
        /// </summary>
        /// <param name="roleToCheck">role to Check</param>
        /// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool CheckRole(string roleToCheck)
        {
            if(!string.IsNullOrEmpty(roleToCheck) && !string.IsNullOrWhiteSpace(roleToCheck))
            {
                if (Regex.IsMatch(roleToCheck, @"^[A-Za-zÀ-ÖØ-öø-ÿ_]+$", RegexOptions.IgnoreCase))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Check of a minimal Password Complexity 
        /// - 8 char Min
        /// - 1 lower + 1 UPPER + 1 number required 
        /// </summary>
        /// <param name="pwdToCheck">password to check </param>
        /// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool CheckPassword(string pwdToCheck)
        { 
            if(!string.IsNullOrEmpty(pwdToCheck) && !string.IsNullOrWhiteSpace(pwdToCheck))
            {
                if(Regex.IsMatch(pwdToCheck, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    return true;

                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Check of an user name , may contain or begin witn an underscore but may not begin with any number
        /// has to contain 1char min (no minimal content saw on analysis)
        /// </summary>
        /// <param name="userName">UserName to Check</param>
        /// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool CheckUserName( string userName)
        { 
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName))
            {
                if(Regex.IsMatch(userName, @"^[a-z_][a-z0-9_]*$" , RegexOptions.IgnoreCase))
                {
                    return true;
                }

                return false;
            }
            return false;
        }

    }
}
