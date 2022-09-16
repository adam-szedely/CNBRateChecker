using System;
using Flurl;
using Flurl.Http;
using Polly.Retry;

namespace SmartyHomework.Services
{
	public interface IExchangeRateConnector
	{
        public void DownloadTxtWithFlurl(string uri, string outputPath, int number);
        public string GenerateUri(DateTime date);
        //public bool IsTransientError(FlurlHttpException exception); //do these need to be part of interface?
        //public AsyncRetryPolicy BuildRetryPolicy();
    }
}
