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
		private int _id_client;
		private string _name;
		private string _surname;
		private string _phone;
		private string _email;


		public int Id_Client
		{
			get { return _id_client; }
			set { _id_client = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Surname
		{
			get { return _surname; }
			set { _surname = value; }
		}
		public string Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}


		//methods

	


	}
}
