using System;
using AppStore.Models.DTO;

namespace AppStore.DL.Interfaces;

public interface IOperatingSystemRepository
{

    void AddOperatingSystem(OperatingSystemDTO os);

    void DeleteOperatingSystem(string Id);

    IEnumerable<OperatingSystemDTO> GetOperatingSystemsByName(IEnumerable<string> osNames);

    OperatingSystemDTO? GetOperatingSystemById(string Id);

}
