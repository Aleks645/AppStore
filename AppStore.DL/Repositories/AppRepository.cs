using System;
using System.Xml.Serialization;
using Microsoft.Extensions.Options;
using AppStore.DL.Interfaces;
using AppStore.Models.DTO;
using MongoDB.Driver;
using AppStore.DL.Configurations;
using AppStore.Models.Models;
using Microsoft.Extensions.Logging;

namespace AppStore.DL.Repositories;

public class AppRepository : IAppRepository
{
    private readonly IMongoCollection<AppDTO> _apps;
    private readonly ILogger<AppRepository> _logger;

    public AppRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig, ILogger<AppRepository> logger)
        {

            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _apps = database.GetCollection<AppDTO>(mongoConfig.CurrentValue.CollectionName);

            _logger = logger;
        }

    public List<AppDTO> GetAllApps(){
        return _apps.Find(app => true).ToList();
    }

    public void AddApp(AppDTO app){
        if (app == null)
        {
            _logger.LogError("App is null");
            return;
        }

        try
        {
            app.Id = Guid.NewGuid().ToString();

            _apps.InsertOne(app);
        }
        catch (Exception e)
        {
            _logger.LogError(e,
                   $"Error adding app {e.Message}-{e.StackTrace}");
        }
           
    }

    public void DeleteApp(string Id){
        _apps.DeleteOne(app => app.Id == Id);
    }

    public AppDTO GetAppById(string Id){
        return _apps.Find(app => app.Id == Id).FirstOrDefault();
    } 

    public void UpdateApp(string id, AppDTO updatedAppDto)
    {
        var filter = Builders<AppDTO>.Filter.Eq(a => a.Id, id);

        var update = Builders<AppDTO>.Update
            .Set(a => a.Name, updatedAppDto.Name)
            .Set(a => a.Description, updatedAppDto.Description)
            .Set(a => a.TotalDownloads, updatedAppDto.TotalDownloads)
            .Set(a => a.OperatingSystems, updatedAppDto.OperatingSystems);

        _apps.UpdateOne(filter, update);
    }


}
