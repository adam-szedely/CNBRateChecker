using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using SmartyHomework.Services;

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

    
