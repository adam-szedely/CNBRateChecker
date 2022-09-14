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
				{ 1, "Bulharsko" },
				{ 2, "Dánsko" },
				{ 3, "EMU" },
                { 4, "Chorvatsko" },
                { 5, "Island" },
                { 6, "Maďarsko" },
                { 7, "Norsko" },
                { 8, "Polsko" },
                { 9, "Rumunsko" },
                { 10, "Švédsko" },
                { 11, "Švýcarsko" },
                { 12, "Turecko" },
                { 13, "Velká Británie" }
            };
		}

        public bool CreateTheFile(string dateName)
        {
			File.Create(@"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data");
            throw new NotImplementedException();
        }

        public void RemoveNonEu()
        {
            //deserialize - split by '|
            //remove non EU
            //save
            //serialize
            throw new NotImplementedException();
        }

        public string GenerateFileName(DateOnly date)
        {
			return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

