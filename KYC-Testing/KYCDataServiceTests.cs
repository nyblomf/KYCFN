using KYC_Aggregation_API_Service.Services;
using KYC_Cache_Service.Interfaces;
using KYC_Data_Fetching_Service.Interfaces;
using KYC_Data_Fetching_Service.Models;
using KYCCore.Models;
using Moq;

namespace KYC_Testing
{
    [TestClass]
    public sealed class KYCDataServiceTests
    {
        [TestMethod]
        public void Correct_Methods_Are_Called_When_GetContactDetails_Is_Called()
        {
            // Arrange
            var cacheMock = new Mock<ICachingService<ContactDetails>>();
            var fetchMock = new Mock<IFetchingService<ContactDetails>>();

            var service = new KYCDataService(
                cacheMock.Object,
                Mock.Of<ICachingService<KYCForm>>(),
                Mock.Of<ICachingService<PersonalDetails>>(),
                fetchMock.Object,
                Mock.Of<IFetchingService<KYCForm>>(),
                Mock.Of<IFetchingService<PersonalDetails>>()
            );

            // Act
            service.GetContactDetails(It.IsAny<string>());

            // Assert
            cacheMock.Verify(c => c.Get(It.IsAny<string>()), Times.Once);
            fetchMock.Verify(f => f.Get(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Correct_Methods_Are_Called_When_GetKYCForm_Is_Called()
        {
            // Arrange
            var cacheMock = new Mock<ICachingService<KYCForm>>();
            var fetchMock = new Mock<IFetchingService<KYCForm>>();

            var service = new KYCDataService(
                Mock.Of<ICachingService<ContactDetails>>(),
                cacheMock.Object,
                Mock.Of<ICachingService<PersonalDetails>>(),
                Mock.Of<IFetchingService<ContactDetails>>(),
                fetchMock.Object,
                Mock.Of<IFetchingService<PersonalDetails>>()
            );

            // Act
            service.GetKYCForm(It.IsAny<string>());

            // Assert
            cacheMock.Verify(c => c.Get(It.IsAny<string>()), Times.Once);
            fetchMock.Verify(f => f.Get(It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void Correct_Methods_Are_Called_When_GetPersonalDetails_Is_Called()
        {
            // Arrange
            var cacheMock = new Mock<ICachingService<PersonalDetails>>();
            var fetchMock = new Mock<IFetchingService<PersonalDetails>>();

            var service = new KYCDataService(
                Mock.Of<ICachingService<ContactDetails>>(),
                Mock.Of<ICachingService<KYCForm>>(),
                cacheMock.Object,
                Mock.Of<IFetchingService<ContactDetails>>(),
                Mock.Of<IFetchingService<KYCForm>>(),
                fetchMock.Object
            );

            // Act
            service.GetPersonalDetails(It.IsAny<string>());

            // Assert
            cacheMock.Verify(c => c.Get(It.IsAny<string>()), Times.Once);
            fetchMock.Verify(f => f.Get(It.IsAny<string>()), Times.Once);
        }
    }
}
