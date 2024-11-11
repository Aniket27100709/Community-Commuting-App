using CCA_BAL.DTO;
using CCA_BAL.Service;
using CCA_DAL.Interface;
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
    public class SmileTest
    {
        private Mock<ISmile> _smileRepository;
        private SmileService _smileService;

        [SetUp]
        public void Setup()
        {
            _smileRepository = new Mock<ISmile>();
            _smileService=new SmileService(_smileRepository.Object);
        }
        [Test]
        public async Task GetSmile_WhenSmilesExist_ReturnsListOfTripDTO()
        {
            // Arrange
            int month = 3; 
            string rpId = "v3";
            var smiles = new List<Smile>
        {
            new Smile { source = "Nashik", destination = "Gurgaon", occupancy = 3 },
            new Smile { source = "Chennai", destination = "Manglore", occupancy = 5 }
        };
            _smileRepository.Setup(repo => repo.RetrieveSmileBasedOnMonthAndProviderId(month, rpId)).ReturnsAsync(smiles);

            // Act
            var result = await _smileService.GetSmile(month, rpId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<TripDTO>>(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Nashik", result[0].source);
            Assert.AreEqual(3, result[0].occupancy);
            
        }


        [Test]
        public async Task GetSmile_WhenNoSmilesExist_ReturnsEmptyList()
        {
            // Arrange
            int month = 3; 
            string rpId = "v2";
            _smileRepository.Setup(repo => repo.RetrieveSmileBasedOnMonthAndProviderId(month, rpId)).ReturnsAsync(new List<Smile>());

            // Act
            var result = await _smileService.GetSmile(month, rpId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<TripDTO>>(result);
            Assert.IsEmpty(result);
        }

    }
}
