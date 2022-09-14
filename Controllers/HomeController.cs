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

        [HttpGet("rates")]
        public async Task<IActionResult> IndexAsync()
        {
            var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data/testFile2.txt";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(@"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=C11E415FEF14B416D2FAE6333AD69E5D?date=3.09.2022");

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var fileInfo = new FileInfo("myPackage.txt");
                using (var fileStream = fileInfo.OpenWrite())
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            return View();
        }

        [HttpGet("download")]
        public IActionResult Download()
        {
            return View();
        }
    }
}

