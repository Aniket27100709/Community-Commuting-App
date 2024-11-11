using CCA_BAL.DTO;
using FluentAssertions.Collections;
using CCA_BAL.Service;
using CCA_DAL.Interface;
using CCA_DAL.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.UnitTests
{
    [TestFixture]
    public class TripTests
    {
        private  Mock<ITripManage> _mockTripRepository;
        private  TripService _tripService;

        [SetUp]
        public void Setup()
        {
            _mockTripRepository = new Mock<ITripManage>();
            _tripService = new TripService(_mockTripRepository.Object);
        }
        [Test]
        public async Task GetTrip_WhenTripExists_ReturnsTripBookingDTOList()
        {
            // Arrange
            var tripId = "r1";
            var trips = new List<Trip>
        {
            new Trip
            {
              
                creatorUserId = "user1",
                vehicleId = "v1",
                rideDate = DateOnly.FromDateTime(DateTime.Now),
                rideTime = TimeOnly.FromTimeSpan(TimeSpan.FromHours(10)),
                rideStatus = "Scheduled",
                noOfSeat = 4,
                seatsFilled = 2,
                fromLoc = "LocationA",
                toLoc = "LocationB"
            }
        };
            _mockTripRepository.Setup(repo => repo.GetTripDetails(tripId)).ReturnsAsync(trips);

            // Act
            var result = await _tripService.getTrip(tripId);

            // Assert
            Assert.NotNull(result);
           Assert.IsInstanceOf<List<TripBookingDTO>>(result);
            var booking = result.First();
         Assert.AreEqual(tripId, booking.TripId);
            Assert.AreEqual(trips.First().creatorUserId, booking.CreatorUserId);
        }
        [Test]
        public async Task GetTrip_WhenNoTripsFound_ReturnsEmptyList()
        {
            // Arrange
            var tripId = "r1";
            _mockTripRepository.Setup(repo => repo.GetTripDetails(tripId)).ReturnsAsync(new List<Trip>());

            // Act
            var result = await _tripService.getTrip(tripId);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<TripBookingDTO>>(result);
            Assert.IsEmpty(result);
        }
   

       
        [Test]
        public async Task CreateTrip_WhenValidInput_ReturnsSuccess()
        {
            // Arrange
            var tripBookingDTO = new TripBookingDTO
            {
                TripId = "r11",
                CreatorUserId = "user11",
                VehicleId = "v11",
                RideDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                RideTime = TimeOnly.FromTimeSpan(TimeSpan.FromHours(10)),
                NoOfSeat = 5,
                SeatsFilled = 3,
                FromLoc = "Pune",
                ToLoc = "Nagpur",
            };
            _mockTripRepository.Setup(repo => repo.AddTripDetails(It.IsAny<Trip>())).ReturnsAsync(1); 

            // Act
            var result = await _tripService.CreateTrip(tripBookingDTO);

            // Assert
            Assert.True(result.Result);

            _mockTripRepository.Verify(repo => repo.AddTripDetails(It.IsAny<Trip>()), Times.Once);
        }


        [Test]
        public async Task UpdateTrip_UpdatesTripDetails_WhenTripExists()
        {
            // Arrange
            var tripId = "r2";
            var tripBookingDTO = new TripBookingDTO
            {
                VehicleId = "v2",
                CreatorUserId = "user2",
                RideDate = DateOnly.FromDateTime(DateTime.Now),
                RideTime = TimeOnly.FromTimeSpan(TimeSpan.FromHours(10)),
                RideStatus = "booked",
                NoOfSeat = 5,
                SeatsFilled = 2,
                FromLoc = "Chennai",
                ToLoc = "Surat"
            };
            var trip = new Trip(); 
            _mockTripRepository.Setup(repo => repo.FindTripById(tripId)).ReturnsAsync(trip);
            _mockTripRepository.Setup(repo => repo.UpdateTripDetails(It.IsAny<Trip>())).ReturnsAsync(1); 

            // Act
            var result = await _tripService.updateTrip(tripId, tripBookingDTO);

            // Assert
            Assert.IsTrue(result.Result);
            _mockTripRepository.Verify(repo => repo.UpdateTripDetails(It.IsAny<Trip>()), Times.Once);
        }
        [Test]
        public async Task CheckTripExist_WhenTripExists_ReturnsTrue()
        {
            // Arrange
            var tripId = "r2";
            var trip = new Trip(); 
            _mockTripRepository.Setup(repo => repo.FindTripById(tripId)).ReturnsAsync(trip);

            // Act
            var result = await _tripService.checkTripExist(tripId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckTripExist_WhenTripDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var tripId = "r1";
            _mockTripRepository.Setup(repo => repo.FindTripById(tripId)).ReturnsAsync((Trip)null);

            // Act
            var result = await _tripService.checkTripExist(tripId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateTrip_WhenTripNotFound_ThrowsException()
        {
            // Arrange
            var tripId = "r21";
            var tripBookingDTO = new TripBookingDTO(); 
            _mockTripRepository.Setup(repo => repo.FindTripById(tripId)).ThrowsAsync(new Exception("Trip not found"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _tripService.updateTrip(tripId, tripBookingDTO));
        }

    }
}
