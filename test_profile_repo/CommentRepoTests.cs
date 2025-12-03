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
    public class CommentRepoTests
    {
        private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
        private DataContext _context;
        private PostRepo _postRepo;
        private ProfileRepo _profileRepo;
        private CommentRepo _commentRepo;

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
            _commentRepo = new CommentRepo(_context);
        }

        [TestMethod]
        public async Task CreateComment_ShouldCreateAComment()
        {


        }

        [TestMethod]
        public async Task DeleteComment_ShouldDeleteACommentOnAPost()
        {
            // Arrange
            #region
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
                Title = "Test Post 1",
                Description = "This is test post 1",
                Location = "Test Location 1",
                Picture = "testpicture1.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            var comment = new Comment
            {
                Id = 1,
                Description = "Your fish is not large enough",
                CreationDate = DateTime.Now,
                Picture = "julemanden.png",
                PostId = 1
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.Add(post);
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            // Act
            _commentRepo.DeleteComment(1);
            var deletedComment = await _context.Comments.FindAsync(1);
            await _context.SaveChangesAsync();

            // Assert
            Assert.IsNull(deletedComment);
        }
    }
}
