using SmartyHomework.Services;
using Syncfusion.Blazor.Diagram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IExchangeRateConnector, ExchangeRateConnector>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();


var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

public class ActualStuffHappening
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IExchangeRateConnector _exchangeRateConnector;
    private readonly IExchangeRateRepository _exchangeRateRepository;

    public ActualStuffHappening(IHttpClientFactory httpClientFactory, IExchangeRateRepository exchangeRateRepository, IExchangeRateConnector exchangeRateConnector)
    {
        _httpClientFactory = httpClientFactory;
        _exchangeRateConnector = exchangeRateConnector;
        _exchangeRateRepository = exchangeRateRepository;
    }

    public static async Task Main(string[] argv)
    {
        var outputPath = @"/Users/adamszedely/Projects/SmartyHomework/SmartyHomework/Data/testFile2.txt";
        var repository = new ExchangeRateRepository();
        var connector = new ExchangeRateConnector();
        connector.DownloadTheFile("https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=C11E415FEF14B416D2FAE6333AD69E5D?date=25.09.2022", outputPath);

        var client = new HttpClient();
        var response = await client.GetAsync(@"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=C11E415FEF14B416D2FAE6333AD69E5D?date=3.09.2022");

        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var fileInfo = new FileInfo("myPackage.zip");
            using (var fileStream = fileInfo.OpenWrite())
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}



//services.AddScoped<IHttpClientServiceImplementation, HttpClientCrudService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientPatchService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientStreamService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientCancellationService>();



// pak maybe blazor a configurovat od jakého do jakého data chci stahovat?

//Připravte program, který provede stažení kurzovního lístku evropských zemí pro období od 1.7.2022 do 1.9.2022 ze stránek České národní banky a tyto uloží do souboru ve formátu JSON.

//Pro každý den bude existovat samostatný soubor.
//Soubor bude obsahovat pouze kurzy evropských zemí.
//Název souboru bude ve tvaru yyyy.MM.dd.json
//Soubory se budou ukládat do podadresáře \Data

