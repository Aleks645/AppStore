using System;

namespace AppStore.Models.Models;

public class App
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description {get; set; } = string.Empty;

    public int TotalDownloads {get; set; }

    public List<string> OperatingSystems { get; set; } = [];
}
