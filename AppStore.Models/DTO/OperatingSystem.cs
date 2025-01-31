using System;

namespace AppStore.Models.DTO;

public class OperatingSystem
{

    public string Name { get; set; } = string.Empty;

    public List<string> Architectures { get; set; } = [];

}   
