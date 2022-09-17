using System;
using Newtonsoft.Json.Linq;
using SmartyHomework.Models;

namespace SmartyHomework.Services
{
	public interface IExchangeRateRepository
	{
        public void SaveEuRates(string path);
        public List<Rates> GetRates(string path);
    }
}





