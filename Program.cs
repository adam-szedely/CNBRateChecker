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


//services.AddScoped<IHttpClientServiceImplementation, HttpClientCrudService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientPatchService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientStreamService>();
//services.AddScoped<IHttpClientServiceImplementation, HttpClientCancellationService>();


//Připravte program, který provede stažení kurzovního lístku evropských zemí pro období od 1.7.2022 do 1.9.2022 ze stránek České národní banky a tyto uloží do souboru ve formátu JSON.

//Pro každý den bude existovat samostatný soubor.
//Soubor bude obsahovat pouze kurzy evropských zemí.
//Název souboru bude ve tvaru yyyy.MM.dd.json
//Soubory se budou ukládat do podadresáře \Data

