using System;
using AppStore.BL.Interfaces;
using AppStore.BL.Services;
using AppStore.DL.Interfaces;
using AppStore.Models.DTO;
using AppStore.Models.Models;
using Moq;
using Xunit;

namespace AppService.Tests;

public class AppServiceBlTests
{

        private Mock<IAppService> _appServiceMock;
        private Mock<IOperatingSystemRepository> _osRepositoryMock;

        public AppServiceBlTests()
        {
            _appServiceMock = new Mock<IAppService>();
            _osRepositoryMock = new Mock<IOperatingSystemRepository>();
        }

        private List<AppDTO> _apps = new List<AppDTO>
        {
            new AppDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "App 1",
                Description = "Description 1",
                TotalDownloads = 1,
                OperatingSystems = ["OS 1", "OS 2"]
            },
            new AppDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "App 2",
                Description = "Description 2",
                TotalDownloads = 2,
                OperatingSystems = ["OS 3", "OS 4"]
            }
        }; 

        private List<OperatingSystemDTO> _os = new List<OperatingSystemDTO>
        {
            new OperatingSystemDTO()
            {
                Id = "9e982c56-85df-4c17-bd0c-8ca75083bd19",
                Name = "Linux",
                Architectures = ["arch1", "arch2"]
            },
            new OperatingSystemDTO()
            {
                Id = "6ccfab23-3a3f-4ceb-87a9-2d9110f7486d",
                Name = "Windows",
                Architectures = ["arch1", "arch2"]
            },
            new OperatingSystemDTO()
            {
                Id = "ac160845-8eb0-472b-9208-02175a9e073e",
                Name = "Android",
                Architectures = ["arch3", "arch4"]
            },

        };

        [Fact]
        public void GetDetailedApps_Ok()
        {
            //setup
            var expectedCount = 2;

            _appServiceMock
                .Setup(x => x.GetAllApps())
                .Returns(_apps);
            _osRepositoryMock
                .Setup(x => x.GetOperatingSystemById(It.IsAny<string>()))
                .Returns((string id) => _os.FirstOrDefault(x => x.Id == id));


            //inject
            var appBlService = new AppBlService(
                _appServiceMock.Object,
                _osRepositoryMock.Object);

            //Act
            var result =
                appBlService.GetDetailedApps();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
}