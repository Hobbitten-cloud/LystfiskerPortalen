using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            // Arrange
            #region
            var post = new Post
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Test",
                Description = "Hejsa"
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
            _context.Add(comment);
            _context.Add(post);
            await _context.SaveChangesAsync();
            
            // Act
            await _commentRepo.CreateComment(comment);

            // Assert
            Assert.IsNotNull(comment);
            Assert.AreEqual(1, comment.Id);
            Assert.AreEqual("Your fish is not large enough", comment.Description);
            Assert.AreEqual("julemanden.png", comment.Picture);
            Assert.AreSame(post, comment.Post);
            Assert.AreSame(post.Id, comment.PostId);
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

        [TestMethod]
        public async Task GetAllComments_ShouldReturnAllComments()
        {
            // Arrange
            #region
            var comment1 = new Comment
            {
                Id = 1,
                Description = "Your fish is not large enough",
                CreationDate = DateTime.Now,
                Picture = "julemanden.png",
                PostId = 1
            };
            var comment2 = new Comment
            {
                Id = 2,
                Description = "Fish",
                CreationDate = DateTime.Now,
                Picture = "fish.png",
                PostId = 2
            };
            var comment3 = new Comment
            {
                Id = 3,
                Description = "Fishermen",
                CreationDate = DateTime.Now,
                Picture = "fishingfishermen.png",
                PostId = 1
            };
            #endregion
            _context.Comments.AddRange(comment1, comment2, comment3);
            await _context.SaveChangesAsync();

            // Act
            var comments = _commentRepo.GetAllComments();

            // Assert
            Assert.IsNotNull(comments);
            Assert.IsInstanceOfType(comments, typeof(Task<List<Comment>>));
            Assert.AreEqual(3, comments.Result.Count);
        }

        [TestMethod]
        public async Task GetCommentById_ShouldGetASpecificComment()
        {
            // Testing code should be applied here

        }

        [TestMethod]
        public async Task UpdateComment_ShouldUpdateACommentInformation()
        {
            // Testing code need to be applied here

        }
    }
}
