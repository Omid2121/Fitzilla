using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Controllers
{
    public class AccountsControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<User> Users { get; set; } = new();

        public AccountsControllerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            Users = UserSeedData.Users();
        }

        [Fact]
        public async Task Register_WithValidUser_ReturnsCreated()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(Users[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{HttpHelper.Urls.AccountURL}/register", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task Register_WithInvalidUser_ReturnsBadRequest()
        {
            // Arrange
            User invalidUser = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidUser), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{HttpHelper.Urls.AccountURL}/register", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Login_WithValidUser_ReturnsOk()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(Users[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{HttpHelper.Urls.AccountURL}/login", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task Login_WithInvalidUser_ReturnsBadRequest()
        {
            // Arrange
            User invalidUser = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidUser), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{HttpHelper.Urls.AccountURL}/login", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        //[Fact]
        //public async Task Logout_WithValidUser_ReturnsOk()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        //[Fact]
        //public async Task Logout_WithInvalidUser_ReturnsBadRequest()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        [Fact]
        public async Task PatchAccount_WithValidUser_ReturnsNoContent()
        {
            // Arrange
            User updatedModel = new()
            {
                Id = Users[0].Id,
                FirstName = "Updated name",
                LastName = "Updated Last name",
                Email = Users[0].Email,
                PasswordHash = Users[0].PasswordHash,
                Birth = Users[0].Birth,
                Gender = "Male",
                Weight = 88,
                Height = 188,
                Measurement = Measurement.IMPERIAL,
                ExerciseTemplates = Users[0].ExerciseTemplates,
                Exercises = Users[0].Exercises,
                Macros = Users[0].Macros,
                Workouts = Users[0].Workouts
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application.json");
            var response = await _client.PatchAsync($"{HttpHelper.Urls.AccountURL}update/{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task PatchAccount_WithInvalidUser_ReturnsBadRequest()
        {
            // Arrange
            User invalidUser = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidUser), Encoding.UTF8, "application.json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.AccountURL}update/{invalidUser.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteAccount_WithValidUser_ReturnsNoContent()
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.AccountURL}delete/{Users[0].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteAccount_WithInvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var invalidId = Guid.Empty;
            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.AccountURL}delete/{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

    }
}
