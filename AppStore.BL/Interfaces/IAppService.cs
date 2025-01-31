using System;
using AppStore.Models.DTO;

namespace AppStore.BL.Interfaces;

public interface IAppService
{

    List<AppDTO> GetAllApps();

    void AddApp(AppDTO app);

    void DeleteApp(string Id);

    AppDTO? GetAppById(string Id);

    void UpdateApp(string Id, AppDTO app);

}
