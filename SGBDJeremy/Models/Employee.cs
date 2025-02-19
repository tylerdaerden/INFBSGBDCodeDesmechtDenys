using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void CheckRole()
        {
            throw new NotImplementedException();
        }

        public void CheckPassword()
        { 
            throw new NotImplementedException(); 
        }

        public void CheckUserName()
        { 
            throw new NotImplementedException(); 
        }


    }
}
