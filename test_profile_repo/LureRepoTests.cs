using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LystFiskerPortalenUnitTest
{
    public class LureRepoTests
    {
        private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
        private DataContext _context;
        private ProfileRepo _profileRepo;
        private PostRepo _postRepo;
        private LureRepo _lureRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new DataContext(options);

            // Initialize repository with in-memory database and mocked AuthenticationStateProvider
            _mockAuthStateProvider = new Mock<AuthenticationStateProvider>();
            _profileRepo = new ProfileRepo(_context, _mockAuthStateProvider.Object);
            _postRepo = new PostRepo(_context);

            // Using DBFactory instead of regular context ??
            _lureRepo = new LureRepo(_context);
        }

        [TestMethod]
        public async Task CreateLure_ShouldCreateALure()
        {
            // Arrange
            var lure = new Lure
            {
                Id = 1,
                Color = "green",
                Type = "small",
                Weight = 32.34,
                Name = "Green Crawfish"
            };

            // Act
            await _lureRepo.CreateLure(lure);
            var createdLure = await _context.Lures.FindAsync(1);

            // Arrange
            Assert.IsNotNull(lure);
            Assert.IsNotNull(lure.Id);
            Assert.IsNotNull(lure.Color);
            Assert.IsNotNull(lure.Type);
            Assert.IsNotNull(lure.Weight);
            Assert.IsNotNull(lure.Name);
            Assert.AreEqual(1, lure.Id);
            Assert.AreEqual("green", lure.Color);
            Assert.AreEqual("small", lure.Type);
            Assert.AreEqual(32.34, lure.Weight);
            Assert.AreEqual("Green Crawfish", lure.Name);
        }
    }
}
