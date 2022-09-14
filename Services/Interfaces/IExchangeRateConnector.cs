using System;
using Flurl;

namespace SmartyHomework.Services
{
	public interface IExchangeRateConnector
	{
		public void DownloadTheFile(string uri, string outputPath);
		public string GenerateUri(string date);
        public string GenerateDate(DateOnly date);
    }
}

// - IExchangeRateConnector (jeho role je načtení dat ze zdroje směnných kurzů)
// 1. mění datum
// 2. checkuje validity?

//0. Create request
//1. Generate request w/ correct date + URL - USE FLURL HERE
//1. Check the data can be loaded
//2. Load the data
//3. Remove non-EU data

//webclient library, načte

////using Flurl;
///1. build url I am coming from - the subdomain etc.
///2. generate (or +1) the date and append it to the end
///3. maybe insert the session id - but why?

//var url = "http://www.some-api.com"
//    .AppendPathSegment("endpoint")
//    .SetQueryParams(new
//    {
//        api_key = _config.GetValue<string>["SomeApiKey"],
//        max_results = 20,
//        q = "Don't worry, I'll get encoded!"
//    })
//    .SetFragment("after-hash");