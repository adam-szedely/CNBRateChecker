using System;
namespace SmartyHomework.Services
{
    public class ExchangeRateConnector : IExchangeRateConnector
    {
        public ExchangeRateConnector()
        {
            var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data";
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        public static async void DownloadFileAsync(string uri
             , string outputPath)
        {
            Uri uriResult;

            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");

            if (!File.Exists(outputPath))
                throw new FileNotFoundException("File not found."
                   , nameof(outputPath));

            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
            File.WriteAllBytes(outputPath, fileBytes);
        }
    
    }
}

