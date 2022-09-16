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

            //Another process je DownloadFlurl ne remove Eu
            var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data";
            var startDate = new DateOnly(2022, 7, 1);
            //while (startDate < startDate.AddDays(3))
            //{
            //.DownloadTxtWithFlurl(_exchangeRateConnector.GenerateUri(startDate), outputPath);
            _exchangeRateRepository.RemoveNonEu(outputPath + "/CurrencyRate.txt");
            //    startDate.AddDays(1);
            //}
            return View();
        }
    }
}

