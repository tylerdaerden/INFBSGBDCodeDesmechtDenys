using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Employee
    {

        private int _id_Employee;
        private string _userName;
        private string _role;
        private bool _isAvalaible;
        private string _passwordHash;
        private string _salt;


        public int IdEmployee 
        { 
            get => _id_Employee;
            set => _id_Employee = value;
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
        public string Salt
        {
            get => _salt; 
            set => _salt = value;
        }


    }
}
