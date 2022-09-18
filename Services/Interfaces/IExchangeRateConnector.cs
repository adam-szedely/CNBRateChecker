using System;
using Flurl;
using Flurl.Http;
using Polly.Retry;

namespace SmartyHomework.Services
{
	public interface IExchangeRateConnector
	{
        public void DownloadRatesTxtFile(string uri, string outputPath, int number);
        public string GenerateRatesUrl(DateTime date);
    }
}
