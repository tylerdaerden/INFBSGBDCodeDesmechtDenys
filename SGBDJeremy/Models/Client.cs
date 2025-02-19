using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public void BookAMeeting(Client clientbook , Meeting meetingbook)
		{
			throw new NotImplementedException();
		}

		public void BrowseHistory()
		{ 
			throw new NotImplementedException(); 
		}
		
		public void EmailValidation(string mail)
		{
			throw new NotImplementedException();
		}

		public void PhoneValidation(string phonenumber)
		{ 
			throw new NotImplementedException(); 
		}

		public void NameValidation(string name)
		{ 
			throw new NotImplementedException();
		}

		public void SurnameValidation(string surname)
		{
			throw new NotImplementedException();
		}



	


	}
}
