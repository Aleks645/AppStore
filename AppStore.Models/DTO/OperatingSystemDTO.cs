using System;

namespace AppStore.Models.DTO;

public class OperatingSystemDTO
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public List<string> Architectures { get; set; } = [];

}   
