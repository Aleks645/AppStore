using System;
using AppStore.Models.DTO;

namespace AppStore.BL.Interfaces;

public interface IOperatingSystemService
{
    void AddOperatingSystem(OperatingSystemDTO os);

    void DeleteOperatingSystem(string Id);

    IEnumerable<OperatingSystemDTO> GetOperatingSystemsByName(IEnumerable<string> osNames);

    OperatingSystemDTO? GetOperatingSystemById(string Id);
}
