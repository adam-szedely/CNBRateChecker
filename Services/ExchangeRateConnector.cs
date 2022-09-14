using System;
using System.Globalization;
using System.Net;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace SmartyHomework.Services
{
    public class ExchangeRateConnector : IExchangeRateConnector
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExchangeRateConnector(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data";
        }

        public ExchangeRateConnector()
        {
        }

        public string GenerateUri(string date)
        {
            return @"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt?date=" + GenerateDate; //10.09.2022
        }

        public async void DownloadTheFile(string uri, string outputPath)
        {
            var client = _httpClientFactory.CreateClient();  //add retries etc
            var response = await client.GetAsync(uri);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var fileInfo = new FileInfo("myPackage.txt");
                using (var fileStream = fileInfo.OpenWrite())
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            //if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
            //    throw new InvalidOperationException("URI is invalid.");

            //if (!File.Exists(outputPath))
            //    throw new FileNotFoundException("File not found."
            //       , nameof(outputPath));      
        }

        public string GenerateDate(DateOnly date)
        {
            return date.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

