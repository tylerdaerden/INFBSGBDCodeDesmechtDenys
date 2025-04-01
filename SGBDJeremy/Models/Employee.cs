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
            // Champs de propriétés
            private int _id;
            private string _firstName;
            private string _lastName;
            private string _phoneNumber;
            private string _email;
            private string _password;
            private string _role;

            //propriétés
            public int Id
            {
                get => _id;
                set => _id = value;
            }

            public string FirstName
            {
                get => _firstName;
                set => _firstName = value;
            }

            public string LastName
            {
                get => _lastName;
                set => _lastName = value;
            }

            public string PhoneNumber
            {
                get => _phoneNumber;
                set => _phoneNumber = value;
            }

            public string Email
            {
                get => _email;
                set => _email = value;
            }

            public string Password
            {
                get => _password;
                set => _password = value;
            }

            public string Role
            {
                get => _role;
                set => _role = value;
            }

            public string FullName => $"{FirstName} {LastName}";




        //methodes non utilisée , le rôle n'est plus validé ou vérifie ici 

        #region Obsolete

        ///// <summary>
        ///// Check if Selected role is valid
        ///// non sensitive case and accept a underscore
        ///// no numbers accepted 
        ///// </summary>
        ///// <param name="roleToCheck">role to Check</param>
        ///// <returns>Boolean true if valid otherwise returns false</returns>
        //public static bool CheckRole(string roleToCheck)
        //    {
        //        if(!string.IsNullOrEmpty(roleToCheck) && !string.IsNullOrWhiteSpace(roleToCheck))
        //        {
        //            if (Regex.IsMatch(roleToCheck, @"^[A-Za-zÀ-ÖØ-öø-ÿ_]+$", RegexOptions.IgnoreCase))
        //            {
        //                return true;
        //            }
        //            return false;
        //        }
        //        return false;
        //    } 
        #endregion

        //Vérifications sont gérée dans les Tools maintenant , plus simple et modulable, methodes obsoletes
        [Obsolete("Gestions Erreur dans tools")]
        #region Obsolete
        ///// <summary>
        ///// Check of a minimal Password Complexity 
        ///// - 8 char Min
        ///// - 1 lower + 1 UPPER + 1 number required 
        ///// </summary>
        ///// <param name="pwdToCheck">password to check </param>
        ///// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool CheckPassword(string pwdToCheck)
        {
            if (!string.IsNullOrEmpty(pwdToCheck) && !string.IsNullOrWhiteSpace(pwdToCheck))
            {
                if (Regex.IsMatch(pwdToCheck, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    return true;

                }
                return false;
            }
            return false;
        } 
        #endregion
        [Obsolete("Gestions Erreur dans tools")]
        #region Obsolete
        ///// <summary>
        ///// Check of an user name , may contain or begin witn an underscore but may not begin with any number
        ///// has to contain 1char min (no minimal content saw on analysis)
        ///// </summary>
        ///// <param name="userName">UserName to Check</param>
        ///// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool CheckUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName))
            {
                if (Regex.IsMatch(userName, @"^[a-z_][a-z0-9_]*$", RegexOptions.IgnoreCase))
                {
                    return true;
                }

                return false;
            }
            return false;
        } 
        #endregion

    }
}
