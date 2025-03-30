using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using static Java.Util.Jar.Attributes;

namespace SGBDJeremy.Models
{
    public class Client
    {
        //props
        private int _clientID;
        private string _name;
        private string _surname;
        private string _phone;
        private string _email;


        public int ClientID
        {
            get => _clientID;
            set => _clientID = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        //methods
        public void BookAMeeting(Client clientbook, Meeting meetingbook)
        {
            throw new NotImplementedException();
        }

        public void BrowseHistory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates an email address with the following criteria:
        /// - Accepts upper and lower case characters, digits, and special characters "._%+-".
        /// - Maximum 64 characters for the local part (before @).
        /// - Maximum 63 characters for the domain part (after @).
        /// - TLD between 2 and 10 characters, supporting modern and professional domains (e.g., @agency, @studio).
        /// - Case-insensitive validation.
        /// Returns true if the email is valid; otherwise, false.
        /// </summary>
        /// <param name="mailtocheck">The email address to validate.</param>
        /// <returns>B>Boolean true if valid otherwise returns false</returns>
        public static bool EmailValidation(object mailtocheck)
        {
            return mailtocheck is string email
                   && !string.IsNullOrWhiteSpace(email)
                   && Regex.IsMatch(email, @"^(?!.*\.\.)([a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]{1,64})@([a-zA-Z0-9-]{1,63})\.([a-zA-Z]{2,10})$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Validate a Belgian Phone Number based on +32 / 0032 indicators or 04 folowed by 8 numbers
        /// returns true if phoneNumber is valid ; otherwise false.
        /// </summary>
        /// <param name="phonenumber"> the phone number to validate</param>
        /// <returns>Boolean true if valid otherwise returns false</returns>
        public static bool PhoneValidation(string phonenumber)
        {
            if (!string.IsNullOrEmpty(phonenumber) && !string.IsNullOrWhiteSpace(phonenumber))
            {
                //Denys note : i adapted to match with "/" or "." separators
                if (Regex.IsMatch(phonenumber, @"^(?:\+32|0032|0)4\d{2}[\s./]?\d{2}[\s./]?\d{2}[\s./]?\d{2}$"))
                {
                    return true;
                }
                return false;
            }
            return false;
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






    }
}
