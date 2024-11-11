using CCA_BAL.DTO;
using CCA_BAL.Interface;
using CCA_BAL.Service;
using CCA_DAL.Interface;
using NUnit.Framework;
using CCA_DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.UnitTests
{
    [TestFixture]
    public class BillTests
    {
        private Mock<ITripManage> _ripManageMock;
        private Mock<IBill> _mockbillRepository;
        private  BillService _billService;

       [SetUp]
       public void Setup()
        {
            _ripManageMock = new Mock<ITripManage>();
            _mockbillRepository = new Mock<IBill>();
            _billService = new BillService(_mockbillRepository.Object,_ripManageMock.Object);
        }
        [Test]
        public async Task RetrieveBill_WhenBillsExist_ReturnsAggregatedBillDTO()
        {
            // Arrange
            int month = 5;
            var bills = new List<billMaster>
        {
            new billMaster { noOfKm = 100, totalbill = 2000, noOfOccupants = 2 },
            new billMaster { noOfKm = 150, totalbill = 3000, noOfOccupants = 3 }
        };
            _mockbillRepository.Setup(repo => repo.GetBill(month)).ReturnsAsync(bills);

            // Act
            var result = await _billService.RetrieveBill(month);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(month, result.month);
            Assert.AreEqual(250, result.noOfKm); 
            Assert.AreEqual(5000, result.totalbill); 
            Assert.AreEqual(5, result.noOfOccupants); 
        }

        [Test]
        public async Task RetrieveBill_WhenNoBillsExist_ReturnsEmptyBillDTO()
        {
            // Arrange
            int month = 5;
            _mockbillRepository.Setup(repo => repo.GetBill(month)).ReturnsAsync(new List<billMaster>());

            // Act
            var result = await _billService.RetrieveBill(month);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(month, result.month);
            Assert.AreEqual(0, result.noOfKm);
            Assert.AreEqual(0, result.totalbill);
            Assert.AreEqual(0, result.noOfOccupants);
        }
        [Test]
        public async Task GenerateBillDetails_WhenBillsExist_ReturnsListOfBillDTOs()
        {
            // Arrange
            string tripId = "r1";
            var bills = new List<billMaster>
        {
            new billMaster { rideId = "r1", month = 1, noOfKm = 100, totalbill = 2000, noOfOccupants = 2 },
            new billMaster { rideId = "r2", month = 1, noOfKm = 150, totalbill = 3000, noOfOccupants = 3 }
        };
            _mockbillRepository.Setup(repo => repo.GetBillDetils(tripId)).ReturnsAsync(bills);

            // Act
            var result = await _billService.generateBillDetails(tripId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<BillDTOs>>(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("r1", result[0].rideId);
            Assert.AreEqual(1, result[0].month);
            Assert.AreEqual(100, result[0].noOfKm);
            Assert.AreEqual(3, result[1].noOfOccupants);
        }

        [Test]
        public async Task GenerateBillDetails_WhenNoBillsExist_ReturnsEmptyList()
        {
            // Arrange
            string tripId = "r1";
            _mockbillRepository.Setup(repo => repo.GetBillDetils(tripId)).ReturnsAsync(new List<billMaster>());

            // Act
            var result = await _billService.generateBillDetails(tripId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<BillDTOs>>(result);
            Assert.IsEmpty(result);
        }
    }
}
