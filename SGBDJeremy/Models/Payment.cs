using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Payment
    {
		private int _paymentID;
		private float _amount;
		private string _paymentMethod;
		private DateTime _paymentDate;


		public int PaymentID
		{
			get => _paymentID; 
			set => _paymentID = value;
		}

		public float Amount
		{
			get => _amount;
			set => _amount = value;
		}

		public string PaymentMethod
		{
			get => _paymentMethod;
			set => _paymentMethod = value;
		}

		public DateTime PaymentDate
		{
			get => _paymentDate; 
			set => _paymentDate = value;
		}


		//methods

		public void PaymentValidation(float paymentAmount , float servicePrice , string paymentMethod)
		{
			throw new NotImplementedException();
		}






	}
}
