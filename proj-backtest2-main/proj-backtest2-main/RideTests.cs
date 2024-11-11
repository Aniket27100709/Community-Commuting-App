using CCA_BAL.DTO;
using CCA_DAL.Models;
using CCA_DAL.Interface;
using CCA_BAL.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.UnitTests
{
  
    [TestFixture]
    public class RideTests
    {
        private Mock<IRideProvide> _mockRideProvideRepository;
        private RideProvideServices _rideProviderService;

        [SetUp]
        public void Setup()
        {
            _mockRideProvideRepository = new Mock<IRideProvide>();
            _rideProviderService = new RideProvideServices(_mockRideProvideRepository.Object);
        }

        [Test]
        public async Task CreateNewRideProvider_WhenValidInput_ReturnsSuccess()
        {
            // Arrange
            var rideProviderDTO = new RideDTO
            {
                BirthDate = new DateOnly(1990, 1, 1),
                Phone = 1234567890,
                EmailId = "test@cognizant.com", 
                FirstName = "John",
                lastName = "Doe",
                dlNo = "ABCD-123-XYZ-567", 
                Adharcard = 123456789012 
                                           
            };
            _mockRideProvideRepository.Setup(repo => repo.AddRider(It.IsAny<RideProvide>())).ReturnsAsync(1); // Assuming '1' indicates success

            // Act
            var result = await _rideProviderService.CreateNewRideProvider(rideProviderDTO);

            // Assert
            Assert.IsTrue(result.Result);
             _mockRideProvideRepository.Verify(repo => repo.AddRider(It.IsAny<RideProvide>()), Times.Once);
        }

        [Test]
        public void CreateNewRideProvider_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var rideProviderDTO = new RideDTO
            {
                BirthDate = new DateOnly(1990, 1, 1),
                Phone = 1234567890,
                EmailId = "test@cognizant.com",
                FirstName = "John",
                lastName = "Doe",
                dlNo = "ABCD-123-XYZ-567",
                Adharcard = 123456789012
            };
            _mockRideProvideRepository.Setup(repo => repo.AddRider(It.IsAny<RideProvide>())).ThrowsAsync(new Exception("Database error"));
            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _rideProviderService.CreateNewRideProvider(rideProviderDTO));
        }
        [Test]
        public async Task UpdateNewRideProvider_WhenValidInput_ReturnsSuccess()
        {
            // Arrange
            string providerId = "RPDo01";
            var rideProviderDTO = new UpdateRideProvideDTO
            {
                birthDate = new DateOnly(1990, 1, 1), 
                phone = 1234567890, 
                emailId = "test@cognizant.com", 
                firstName = "John",
                lastName = "Doe", 
                dlNo = "ABC-123-XYZ-567", 
                adharcard = 123456789012 
                                          
            };
            var rideProvider = new RideProvide();
            _mockRideProvideRepository.Setup(repo => repo.FindRideProviderById(providerId)).ReturnsAsync(rideProvider);
            _mockRideProvideRepository.Setup(repo => repo.UpdateRider(It.IsAny<RideProvide>())).ReturnsAsync(1);

            // Act
            var result = await _rideProviderService.UpdateNewRideProvider(providerId, rideProviderDTO);

            // Assert
            Assert.IsTrue(result.Result);
            _mockRideProvideRepository.Verify(repo => repo.UpdateRider(It.IsAny<RideProvide>()), Times.Once);
        }

    }

}
