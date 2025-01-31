using System;
using AppStore.Models.DTO;
using AppStore.Models.Models;

namespace AppStore.DL.Interfaces;

public interface IAppRepository
{
    List<AppDTO> GetAllApps();

    void AddApp(AppDTO app);

    void DeleteApp(string Id);

    AppDTO? GetAppById(string Id);

    void UpdateApp(string Id, AppDTO app);


}
