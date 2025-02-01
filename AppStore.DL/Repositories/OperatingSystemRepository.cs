using System;
using AppStore.DL.Configurations;
using AppStore.DL.Interfaces;
using AppStore.Models.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppStore.DL.Repositories;

public class OperatingSystemRepository : IOperatingSystemRepository
{
    private readonly IMongoCollection<OperatingSystemDTO> _os;
    private readonly ILogger<OperatingSystemRepository> _logger;

    public OperatingSystemRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig, ILogger<OperatingSystemRepository> logger)
    {

        var client = new MongoClient(
            mongoConfig.CurrentValue.ConnectionString);

        var database = client.GetDatabase(
            mongoConfig.CurrentValue.DatabaseName);

        _os = database.GetCollection<OperatingSystemDTO>($"{nameof(OperatingSystem)}s");

        _logger = logger;
    }

    public void AddOperatingSystem(OperatingSystemDTO os){
        if (os == null)
        {
            _logger.LogError("Operating system is null");
            return;
        }

        try
        {
            os.Id = Guid.NewGuid().ToString();

            _os.InsertOne(os);
        }
        catch (Exception e)
        {
            _logger.LogError(e,
               $"Error adding os {e.Message}-{e.StackTrace}");
        }
           
    }

    public void DeleteOperatingSystem(string Id){
        _os.DeleteOne(os => os.Id == Id);
    }

    public IEnumerable<OperatingSystemDTO> GetOperatingSystemsByName(IEnumerable<string> osNames){
        var result = _os.Find(os => osNames.Contains(os.Name)).ToList();
        return result;
    }

    public OperatingSystemDTO? GetOperatingSystemById(string id){
        if (string.IsNullOrEmpty(id)) return null;

        return _os.Find(m => m.Id == id).FirstOrDefault();
    }
}
