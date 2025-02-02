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
    public class MovieBlServiceTests
    {
        private Mock<IAppService> _appServiceMock;
        private Mock<IOperatingSystemRepository> _osRepositoryMock;

        public MovieBlServiceTests()
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
                OperatingSystems = ["OS 1", "OS 2"]
            },
            new AppDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "App 2",
                OperatingSystems = ["OS 3", "OS 4"]
            }
        }; 

        private List<OperatingSystemDTO> _os = new List<OperatingSystemDTO>
        {
            new OperatingSystemDTO()
            {
                Id = "9e982c56-85df-4c17-bd0c-8ca75083bd19",
                Name = "Linux"
            },
            new OperatingSystemDTO()
            {
                Id = "6ccfab23-3a3f-4ceb-87a9-2d9110f7486d",
                Name = "Windows"
            },
            new OperatingSystemDTO()
            {
                Id = "ac160845-8eb0-472b-9208-02175a9e073e",
                Name = "Android"
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
            var movieBlService = new AppBlService(
                _appServiceMock.Object,
                _osRepositoryMock.Object);

            //Act
            var result =
                movieBlService.GetDetailedApps();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

    }
}
