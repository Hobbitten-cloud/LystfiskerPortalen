using LystFiskerPortalenWEB.Data;
using LystFiskerPortalenWEB.Models;
using LystFiskerPortalenWEB.Repo;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LystFiskerPortalenUnitTest
{
	[TestClass]
	public class ProfileRepoTests
	{
		private Mock<AuthenticationStateProvider> _mockAuthStateProvider;
		private DataContext _context;
		private ProfileRepo _repo;

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
			_repo = new ProfileRepo(_context, _mockAuthStateProvider.Object);
		}

		[TestMethod]
		public async Task GetAllProfiles_ShouldReturnListOfProfiles()
		{
			// Ensure a fresh DataContext for each test method. Before this was here it kept the profile from the previous test and count was 3 instead of 2
			var options = new DbContextOptionsBuilder<DataContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid())  // Unique database name for each test
				.Options;

			_context = new DataContext(options);

			// Initialize repository with in-memory database and mocked AuthenticationStateProvider
			_mockAuthStateProvider = new Mock<AuthenticationStateProvider>();
			_repo = new ProfileRepo(_context, _mockAuthStateProvider.Object);

			// Arrange: Add some profiles to the in-memory database
			_context.Profiles.Add(new Profile { Id = "1", UserName = "John Doe", ImagePath = "path/to/image.jpg", Role = "User" });
			_context.Profiles.Add(new Profile { Id = "2", UserName = "Jane Smith", ImagePath = "path/to/image.jpg", Role = "User" });
			await _context.SaveChangesAsync();

			// Act: Call the method to retrieve all profiles
			var result = await _repo.GetAllProfiles();

			// Assert: Ensure that the correct number of profiles are returned
			Assert.IsTrue(result.Count > 0);
			Assert.AreEqual(2, result.Count);
		}

		[TestMethod]
		public async Task GetProfileById_ShouldReturnProfile_WhenProfileExists()
		{
			// Arrange: Add a profile to the in-memory database
			var profile = new Profile { Id = "5", UserName = "John Doe", ImagePath = "path/to/image.jpg", Role = "User" };
			_context.Profiles.Add(profile);
			await _context.SaveChangesAsync();

			// Act: Retrieve the profile by its ID
			var result = await _repo.GetProfileById("5");

			// Assert: Ensure the profile returned matches the one added
			Assert.IsNotNull(result);
			Assert.AreEqual("John Doe", result.UserName);
		}

		[TestMethod]
		public async Task AddProfile_ShouldAddProfileToDatabase()
		{
			// Arrange: Create a new profile
			var profile = new Profile { Id = "3", UserName = "Mark Spencer", ImagePath = "path/to/image.jpg", Role = "User"
			};

			// Act: Add the profile to the repository
			await _repo.AddProfile(profile);

			// Assert: Ensure the profile was added to the database
			var result = await _repo.GetProfileById("3");
			Assert.IsNotNull(result);
			Assert.AreEqual("Mark Spencer", result.UserName);
			Assert.AreEqual("path/to/image.jpg", result.ImagePath);
			Assert.AreEqual("User", result.Role);
		}

		[TestMethod]
		public async Task UpdateProfile_ShouldUpdateProfile()
		{
			// Arrange: Add a profile to the database
			var profile = new Profile { Id = "4", UserName = "John Doe", ImagePath = "path/to/image.jpg", Role = "User" };
			_context.Profiles.Add(profile);
			await _context.SaveChangesAsync();

			// Act: Update the profile's name
			profile.UserName = "John Updated";
			await _repo.UpdateProfile(profile);

			// Assert: Ensure the profile name was updated
			var updatedProfile = await _repo.GetProfileById("4");
			Assert.IsNotNull(updatedProfile);
			Assert.AreEqual("John Updated", updatedProfile.UserName);
		}

		[TestMethod]
		public async Task DeleteProfile_ShouldRemoveProfile()
		{
			// Arrange: Add a profile to the database
			var profile = new Profile { Id = "1", UserName = "John Doe", ImagePath = "path/to/image.jpg", Role = "User" };
			_context.Profiles.Add(profile);
			await _context.SaveChangesAsync();

			// Act: Delete the profile
			await _repo.DeleteProfile("1");

			// Assert: Ensure the profile no longer exists
			var result = await _repo.GetProfileById("1");
			Assert.IsNull(result);
		}
	}
}
