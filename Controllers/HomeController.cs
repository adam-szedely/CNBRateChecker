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
        private readonly IExchangeRateConnector _exchangeRateConnector;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public HomeController(IExchangeRateRepository exchangeRateRepository, IExchangeRateConnector exchangeRateConnector)
        {
            _exchangeRateConnector = exchangeRateConnector;
            _exchangeRateRepository = exchangeRateRepository;
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"Data/";
            DateTime begindate = Convert.ToDateTime("01/07/2022");
            DateTime enddate = Convert.ToDateTime("01/08/2022");

            while (begindate < enddate)
            {
                if (begindate.DayOfWeek == DayOfWeek.Saturday)
                {
                    begindate = begindate.AddDays(2);
                }
                await _exchangeRateConnector.DownloadRatesTxtFile(_exchangeRateConnector.GenerateRatesUrl(begindate), path, begindate.Day);
                _exchangeRateRepository.FilterOutInvalidRates(path + "CurrencyRate" + begindate.Day + ".txt", begindate.ToString("yyyy/MM/dd"));
                begindate = begindate.AddDays(1);
            }
            return Ok();
        }
    }
}

