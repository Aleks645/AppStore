using System;
using AppStore.Models.Views;

namespace AppStore.BL.Interfaces;

public interface IAppBlService
{
    List<AppsView> GetDetailedApps();
}
