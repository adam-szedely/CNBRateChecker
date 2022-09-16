using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using SmartyHomework.Services;


namespace SmartyHomework.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExchangeRateConnector _exchangeRateConnector;
        private readonly IExchangeRateRepository _exchangeRateRepository;
        public HomeController(IHttpClientFactory httpClientFactory, IExchangeRateRepository exchangeRateRepository, IExchangeRateConnector exchangeRateConnector)
        {
            _httpClientFactory = httpClientFactory;
            _exchangeRateConnector = exchangeRateConnector;
            _exchangeRateRepository = exchangeRateRepository;
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download()
        {

            //1. Download stuff
            //2. Filter through and save the file
            //3. Repeate until

            var FileNameTracker = 1;
            var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data/";
            DateTime begindate = Convert.ToDateTime("01/08/2022");
            DateTime enddate = Convert.ToDateTime("04/08/2022");
            while (begindate < enddate)
            {
                _exchangeRateConnector.DownloadTxtWithFlurl(_exchangeRateConnector.GenerateUri(begindate), outputPath, FileNameTracker);
               //_exchangeRateRepository.RemoveNonEu(outputPath + "CurrencyRate" + FileNameTracker + ".txt");
                begindate = begindate.AddDays(1);
                FileNameTracker++;
            }
            return View();
        }
    }
}

