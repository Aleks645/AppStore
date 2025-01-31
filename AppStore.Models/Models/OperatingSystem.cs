using System;

namespace AppStore.Models.Models;

public class OperatingSystem
{

    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public List<string> Architectures { get; set; } = [];

}   
