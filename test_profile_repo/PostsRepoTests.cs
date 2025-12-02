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
    [TestClass]
    public class PostsRepoTests
    {

        private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
        private DataContext _context;
        private PostRepo _postRepo;
        private ProfileRepo _profileRepo;

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
        }

        [TestMethod]
        public async Task CreatePost_ShouldCreateAPost()
        {
            var profile = new Profile
            {
                Id = "1",
                UserName = "Test User",
                ImagePath = "testimage.jpg",
                Role = "User"
            };
            var post = new Post
            {
                Id = 1,
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };

            await _postRepo.CreatePost(post);
            var createdPost = await _context.Posts.FindAsync(1);

            Assert.IsNotNull(createdPost);
            Assert.AreEqual("Test Post", createdPost.Title);
            Assert.AreEqual("This is a test post", createdPost.Description);
            Assert.AreEqual("Test Location", createdPost.Location);
            Assert.AreEqual("testpicture.jpg", createdPost.Picture);
            Assert.AreEqual(1, createdPost.TechniqueId);
            Assert.AreEqual(1, createdPost.LureId);
            Assert.AreEqual(0, createdPost.Likes);
        }

        [TestMethod]
        public void GetAllPosts_ShouldReturnListOfPosts()
        {

        }
    }
}
