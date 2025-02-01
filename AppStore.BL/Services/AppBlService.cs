using System;
using AppStore.BL.Interfaces;
using AppStore.DL.Interfaces;
using AppStore.Models.Views;

namespace AppStore.BL.Services;

public class AppBlService : IAppBlService
{
        private readonly IAppService _appService;
        private readonly IOperatingSystemRepository _osRepository;

        public AppBlService(
            IAppService appService,
            IOperatingSystemRepository osRepository)
        {
            _appService = appService;
            _osRepository = osRepository;
        }

        public List<AppsView> GetDetailedApps()
        {
            var result = new List<AppsView>();

            var apps = _appService.GetAllApps();

            foreach (var app in apps)
            {
                var appView = new AppsView
                {
                    AppId = app.Id,
                    AppName = app.Name,
                    OperatingSystems = _osRepository.GetOperatingSystemsByName(app.OperatingSystems)
                };

                result.Add(appView);
            }

            return result;
        }
}
