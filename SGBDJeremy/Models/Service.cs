using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Service
    {
		private int _service_Id;
		private string _serviceName;
		private string _description;
		private float _price;

		public int Service_Id
		{
			get => _service_Id;
			set => _service_Id = value;
		}

		public string Service_Name
		{
			get => _serviceName;  
			set => _serviceName = value;  
		}

		public string Description
		{ 
			get => _description;  
			set =>  _description = value;  
		}

		public float Price
		{ 
			get => _price;  
			set => _price = value; 
		}


		public void DisplayDescription()
		{
			throw new NotImplementedException();
		}



	}
}
