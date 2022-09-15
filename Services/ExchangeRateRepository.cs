using System;
using System.Globalization;
using Syncfusion.Blazor.RichTextEditor.Internal;

namespace SmartyHomework.Services
{
	public class ExchangeRateRepository : IExchangeRateRepository
	{
		public ExchangeRateRepository()
		{
		}

        public void CreateTheFile(string dateName)
        {
			File.Create(@"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data" + GenerateFileName + ".json");
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

        public void DeleteTheLines(string fileLocation)
        {

            using (StreamReader reader = new StreamReader("C:\\input"))
            {
                string line = null;
                int line_number = 0;
                int line_to_delete = 12;

                using (StreamWriter writer = new StreamWriter("C:\\output"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
        }

        public void ReadTheFile(string fileLocation)
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

            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileLocation).Where(l => l != "removeme");

            var data = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data/testFlurl.json";
            foreach (var line in data)
            {
                var currentLine = line.ToString().Split('|').ToList();
                if (validCountries.ContainsValue(currentLine[0]))
                {
                }
            }
        }
    }
}

