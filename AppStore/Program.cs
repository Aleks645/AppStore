using AppStore.BL;
using AppStore.DL.Configurations;
using AppStore.Models.DTO;
using AppStore.Models.Models;
using Mapster;
using MapsterMapper;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(theme:AnsiConsoleTheme.Code)
    .CreateLogger();

builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration.GetSection("MongoDBSettings")
);

builder.Services
    .RegisterDataLayer()
    .RegisterBusinessLayer();

TypeAdapterConfig<App, AppDTO>.NewConfig().TwoWays();
builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
