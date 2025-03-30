using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGBDJeremy.Tools.CheckTools
{
    public class User_Check_Entries
    {
        /// <summary>
        /// Validates an email address with the following criteria:
        /// - Accepts upper and lower case characters, digits, and special characters "._%+-".
        /// - Maximum 64 characters for the local part (before @).
        /// - Maximum 63 characters for the domain part (after @).
        /// - TLD between 2 and 10 characters, supporting modern and professional domains (e.g., @agency, @studio).
        /// - Case-insensitive validation.
        /// Returns true if the email is valid; otherwise, false.
        /// </summary>
        /// <param name="mailtocheck"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckEmail(object mailtocheck)
        {
            // type verification
            if (mailtocheck is not string email)
            {
                throw new ArgumentException("Erreur : l'email doit être une chaîne de caractères.");
            }
            var regex = new Regex(@"^(?!.*\.\.)([a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]{1,64})@([a-zA-Z0-9-]{1,63})\.([a-zA-Z]{2,10})$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }


        /// <summary>
        /// Validate 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckName(object name)
        {
            // type and null or white space verification
            if (name is not string nameStr || string.IsNullOrWhiteSpace(nameStr))
            {
                throw new ArgumentException("Erreur,name doit être une chaîne de caractères non vide.");
            }
            // Vérification de la longueur
            if (nameStr.Length > 50)
            {
                return false;
            }
            var regex = new Regex(@"^([A-ZÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ][a-zàâäéèêëïîôöùûüç]+)([-\s][A-ZÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ][a-zàâäéèêëïîôöùûüç]+)*$");
            if (!regex.IsMatch(nameStr))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate a FamilyName : add of optionnal group in regex so it can accept composed name (ex Name-Name2 , present in certains culture or in married couples)
        /// Accept a white Space between some name char (case of Name with space like "Particule Name"
        /// Add of latin char (in case of Name containing latin char like "é" , "è" , "û" , "ö" etc ...
        /// </summary>
        /// <param name="name">the name to validate</param>
        /// <returns>>Boolean true if valid otherwise returns false</returns>
        public static bool NameValidation(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                if (Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ]+(?:[-' ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Validate a SurName : add of optionnal group in regex so it can accept composed name up to 3 occurence (ex SurName-SurName2-Surname3)
        /// Accept a white Space between some name char (case of Name with space like "Surname1 Surname2"
        /// Add of latin char (in case of Name containing latin char like "é" , "è" , "û" , "ö" etc ...
        /// </summary>
        /// <param name="surname"></param>
        /// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool SurnameValidation(string surname)
        {
            if (!string.IsNullOrEmpty(surname) && !string.IsNullOrWhiteSpace(surname))
            {
                if (Regex.IsMatch(surname, @"^[A-Za-zÀ-ÖØ-öø-ÿ]+(?:[-' ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Validate a Belgian Phone Number based on +32 / 0032 indicators or 04 folowed by 8 numbers
        /// returns true if phoneNumber is valid ; otherwise false.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckPhoneNumber(object phoneNumber)
        {
            if (phoneNumber is not string number || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Erreur , phoneNumber doit être une chaîne de caractères (non vide.)");
            }
            var regex = new Regex(@"^(\+32|0032|0)?\s?4\d{2}([/\s.-]?\d{2}){3}$");
            if (!regex.IsMatch(number))
            {
                return false;
            }
            return true;
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




    }
}
