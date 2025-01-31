using System;
using AppStore.BL.Interfaces;
using AppStore.DL.Interfaces;
using AppStore.Models.DTO;

namespace AppStore.BL.Services;

public class AppService : IAppService
{
    private readonly IAppRepository _appRepository;
    private readonly IOperatingSystemRepository _operatingSystemRepository;

    public AppService(IAppRepository appRepository, IOperatingSystemRepository operatingSystemRepository){

        _appRepository = appRepository;
        _operatingSystemRepository = operatingSystemRepository;

    }

    public List<AppDTO> GetAllApps(){
        return _appRepository.GetAllApps();
    }

    public void AddApp(AppDTO app){
        _appRepository.AddApp(app);
    }

    public void DeleteApp(string Id){
        _appRepository.DeleteApp(Id);
    }

    public AppDTO? GetAppById(string Id){
        return _appRepository.GetAppById(Id);
    }

    public void UpdateApp(string Id, AppDTO updatedAppDto){
        _appRepository.UpdateApp(Id, updatedAppDto);
    }

}
