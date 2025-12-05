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
    public class TechniqueRepoTests
    {
        private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
        private DataContext _context;
        private ProfileRepo _profileRepo;
        private PostRepo _postRepo;
        private TechniqueRepo _techniqueRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new DataContext(options);
            _factoryContext = new IDbContextFactory<DataContext> _factory;

            // Initialize repository with in-memory database and mocked AuthenticationStateProvider
            _mockAuthStateProvider = new Mock<AuthenticationStateProvider>();
            _profileRepo = new ProfileRepo(_context, _mockAuthStateProvider.Object);
            _postRepo = new PostRepo(_context);

            // Using DBFactory instead of regular context ??
            _techniqueRepo = new TechniqueRepo(_factory);
        }

        [TestMethod]
        public async Task CreateTech_ShouldCreateATechnique()
        {
            // Arrange
            var tech = new Technique
            {
                Id = 1,
                Name = "Bernshire Technique"
            };

            // Act
            await _techniqueRepo.CreateTech(tech);
            var createdLure = await _context.Techniques.FindAsync(1);

            // Arrange
            Assert.IsNotNull(createdLure);
            Assert.IsNotNull(createdLure.Id);
            Assert.IsNotNull(createdLure.Color);
            Assert.IsNotNull(createdLure.Type);
            Assert.IsNotNull(createdLure.Weight);
            Assert.IsNotNull(createdLure.Name);
            Assert.AreEqual(1, createdLure.Id);
            Assert.AreEqual("green", createdLure.Color);
            Assert.AreEqual("small", createdLure.Type);
            Assert.AreEqual(32.34, createdLure.Weight);
            Assert.AreEqual("Green Crawfish", createdLure.Name);
        }

    }
}
