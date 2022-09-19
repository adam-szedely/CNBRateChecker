using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartyHomework.Models;
using Syncfusion.Blazor.RichTextEditor.Internal;

namespace SmartyHomework.Services
{
	public class ExchangeRateRepository : IExchangeRateRepository
	{
        public List<Rates> GetRates(string path)
        {
                var jsonString = File.ReadAllText(path);
                return (List<Rates>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(List<Rates>));
        }

        private bool IsTheCountryValid(string country)
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
            }.Values.ToHashSet();
            return validCountries.Contains(country);
        }

        public void FilterOutInvalidRates(string path, string name)
        {
            try
            {
                var targetLocation = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data/";
                var model = File.ReadAllLines(path).Skip(2).Select(p => new Rates
                {
                    Country = p.Split("|")[0],
                    Currency = p.Split("|")[1],
                    Amount = p.Split("|")[2],
                    Code = p.Split("|")[3],
                    Rate = p.Split("|")[4],
                }
                );

                List<Rates> rates = model.Where(model => IsTheCountryValid(model.Country)).ToList();

                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(rates.ToArray(), Formatting.Indented);

                System.IO.File.WriteAllText(targetLocation + name + ".json", jsonString);

                System.IO.File.Delete(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"Unable to read file:" + path.ToString());
            }
        }
    }
}

