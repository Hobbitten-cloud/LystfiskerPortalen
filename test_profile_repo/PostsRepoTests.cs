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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion

            // Act
            await _postRepo.CreatePost(post);
            var createdPost = await _context.Posts.FindAsync(1);

            // Assert
            Assert.IsNotNull(createdPost);
            Assert.AreEqual(1, createdPost.Id);
            Assert.AreEqual("Test Post", createdPost.Title);
            Assert.AreEqual("This is a test post", createdPost.Description);
            Assert.AreEqual("Test Location", createdPost.Location);
            Assert.AreEqual("testpicture.jpg", createdPost.Picture);
            Assert.AreEqual(1, createdPost.TechniqueId);
            Assert.AreEqual(1, createdPost.LureId);
            Assert.AreEqual(0, createdPost.Likes);
        }

        [TestMethod]
        public async Task GetPostById_ShouldReturnPostById()
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
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.Add(post);

            // Act
            await _context.SaveChangesAsync();
            await _postRepo.GetPostById(1);

            // Assert
            Assert.IsNotNull(post);
            Assert.AreEqual(1, post.Id);
            Assert.AreEqual("Test Post", post.Title);
        }

        [TestMethod]
        public async Task GetAllPosts_ShouldReturnListOfPosts()
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
            _context.Profiles.Add(profile);

            var post1 = new Post
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
            var post2 = new Post
            {
                Id = 2,
                Title = "Test Post 2",
                Description = "This is test post 2",
                Location = "Test Location 2",
                Picture = "testpicture2.jpg",
                TechniqueId = 2,
                LureId = 2,
                Likes = 0,
                ProfileID = profile.Id
            };
            var post3 = new Post
            {
                Id = 3,
                Title = "Test Post 3",
                Description = "This is test post 3",
                Location = "Test Location 3",
                Picture = "testpicture3.jpg",
                TechniqueId = 3,
                LureId = 3,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Posts.AddRange(post1, post2, post3);
            await _context.SaveChangesAsync();

            // Act
            var posts = _postRepo.GetAllPosts();

            // Assert
            Assert.IsNotNull(posts);
            Assert.IsInstanceOfType(posts, typeof(Task<List<Post>>));
            Assert.AreEqual(3, posts.Result.Count);
        }

        [TestMethod]
        public async Task UpdatePost_ShouldUpdateAPost()
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
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            // Act
            post.Title = "Updated Test Post";
            post.Description = "This is an updated test post";
            await _postRepo.UpdatePost(post);
            var updatedPost = await _context.Posts.FindAsync(1);

            // Assert
            Assert.IsNotNull(updatedPost);
            Assert.AreEqual("Updated Test Post", updatedPost.Title);
            Assert.AreEqual("This is an updated test post", updatedPost.Description);
        }

        [TestMethod]
        public async Task DeletePost_ShouldDeleteAPost()
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
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            // Act
            await _postRepo.DeletePost(1);
            var deletedPost = await _context.Posts.FindAsync(1);

            // Assert
            Assert.IsNull(deletedPost);
        }

        [TestMethod]
        public async Task LikePost_ShouldIncrementLike()
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
                Title = "Test Post",
                Description = "This is a test post",
                Location = "Test Location",
                Picture = "testpicture.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            // Act
            await _postRepo.LikePost(post);
            var likedPost = await _context.Posts.FindAsync(1);

            // Assert
            Assert.IsNotNull(likedPost);
            Assert.AreEqual(1, likedPost.Likes);
        }

        [TestMethod]
        public async Task GetPostsByUser_ShouldGetPostsFromSpecificUser()
        {
            // Arrange
            #region
            var profile = new Profile
            {
                Id = "1",
                UserName = "TestUser1",
                ImagePath = "testimage.jpg",
                Role = "User"
            };
            var post1 = new Post
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
            var post2 = new Post
            {
                Id = 2,
                Title = "Test Post 2",
                Description = "This is test post 1",
                Location = "Test Location 1",
                Picture = "testpicture1.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            var post3 = new Post
            {
                Id = 3,
                Title = "Test Post 3",
                Description = "This is test post 1",
                Location = "Test Location 1",
                Picture = "testpicture1.jpg",
                TechniqueId = 1,
                LureId = 1,
                Likes = 0,
                ProfileID = profile.Id
            };
            #endregion
            _context.Profiles.Add(profile);
            _context.Posts.AddRange(post1, post2, post3);
            await _context.SaveChangesAsync();

            // Act
            _postRepo.GetPostsByUser("1");
            var postsByUser = await _postRepo.GetPostsByUser("1");


            // Assert
            Assert.IsNotNull(postsByUser);
            Assert.AreEqual(3, postsByUser.Count);
            Assert.AreNotSame(post1, postsByUser[1]);
        }
    }
}
