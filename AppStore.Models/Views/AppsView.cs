using System;
using AppStore.Models.DTO;

namespace AppStore.Models.Views;

public class AppsView
{
    public string AppId { get; set; } = string.Empty;

    public string AppName { get; set; } = string.Empty;

    public string AppDescription {get; set; } = string.Empty;

    public int TotalDownloads {get; set; }

    public IEnumerable<OperatingSystemDTO> OperatingSystems { get; set; } = [];

}
