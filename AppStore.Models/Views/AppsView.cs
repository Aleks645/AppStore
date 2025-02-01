using System;
using AppStore.Models.DTO;

namespace AppStore.Models.Views;

public class AppsView
{
    public string AppId { get; set; } = string.Empty;

    public string AppName { get; set; } = string.Empty;

    public IEnumerable<OperatingSystemDTO> OperatingSystems { get; set; } = [];

}
