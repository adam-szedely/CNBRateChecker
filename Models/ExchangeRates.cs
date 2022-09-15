using System;
namespace SmartyHomework.Models
{
	public class ExchangeRates
	{
        public string Date { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }

        public ExchangeRates()
		{
		}
	}
}

