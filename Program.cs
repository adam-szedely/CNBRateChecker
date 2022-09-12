using SmartyHomework.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IExchangeRateConnector, ExchangeRateConnector>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();

var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();