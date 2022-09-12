using System;
using System.Globalization;

namespace SmartyHomework.Services
{
	public class ExchangeRateRepository : IExchangeRateRepository
	{
		public ExchangeRateRepository()
		{
			var validCountries = new Dictionary<int, string>
			{
				{ 1, "Island" },
				{ 2, "Island" },
				{ 3, "Whatever" },
			};
		}

        public bool CreateTheFile(string dateName)
        {
			File.Create(@"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data");
            throw new NotImplementedException();
        }

        public string GenerateFileName(DateOnly date)
        {
			return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

