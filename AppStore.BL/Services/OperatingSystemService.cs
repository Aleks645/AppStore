using System;
using AppStore.BL.Interfaces;
using AppStore.DL.Interfaces;
using AppStore.Models.DTO;

namespace AppStore.BL.Services;

public class OperatingSystemService : IOperatingSystemService
{
    private readonly IAppRepository _appRepository;
    private readonly IOperatingSystemRepository _operatingSystemRepository;

    public OperatingSystemService(IAppRepository appRepository, IOperatingSystemRepository operatingSystemRepository){

        _appRepository = appRepository;
        _operatingSystemRepository = operatingSystemRepository;

    }
    public void AddOperatingSystem(OperatingSystemDTO os){
        _operatingSystemRepository.AddOperatingSystem(os);
    }

    public void DeleteOperatingSystem(string Id){
        _operatingSystemRepository.DeleteOperatingSystem(Id);
    }

    public IEnumerable<OperatingSystemDTO> GetOperatingSystemsByName(IEnumerable<string> osNames){
       return _operatingSystemRepository.GetOperatingSystemsByName(osNames);
    }

    public OperatingSystemDTO? GetOperatingSystemById(string id){
        return _operatingSystemRepository.GetOperatingSystemById(id);
    }
}
