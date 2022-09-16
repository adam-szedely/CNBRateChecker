using System;
using System.Globalization;
using System.Net;
using Flurl;
using Flurl.Http;
using Polly;
using Polly.Retry;
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
        }

        private AsyncRetryPolicy BuildRetryPolicy()
        {
            var retryPolicy = Policy
               .Handle<FlurlHttpException>(IsTransientError)
               .WaitAndRetryAsync(3, retryAttempt =>
               {
                   var nextAttemptIn = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                   Console.WriteLine($"Retry attempt {retryAttempt} to make request. Next try on {nextAttemptIn.TotalSeconds} seconds.");
                   return nextAttemptIn;
               });
            return retryPolicy;
        }

        private bool IsTransientError(FlurlHttpException exception)
        {
            int[] httpStatusCodesWorthRetrying =
            {
                 (int)HttpStatusCode.RequestTimeout, // 408
                 (int)HttpStatusCode.BadGateway, // 502
                 (int)HttpStatusCode.ServiceUnavailable, // 503
                 (int)HttpStatusCode.GatewayTimeout // 504
             };
            return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
        }

        public string GenerateUri(DateTime date)
        {
            var url = "https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt"
                    .SetQueryParams(new
                    {
                        jsessiond = "C11E415FEF14B416D2FAE6333AD69E5D",
                        date = date.ToString("dd/MM/yyyy")
                    });
            return url;
        }

        public async void DownloadTxtWithFlurl(string uri, string outputPath, int number)
        {
            var a = @"/CurrencyRate" + number + ".txt";
            var policy = BuildRetryPolicy();
            var path = await policy.ExecuteAsync(() => uri
            .DownloadFileAsync(outputPath, @"CurrencyRate" + number + ".txt"));
            
            //Always overwrite currency rate.txt - only need one file
        }
    }
}

