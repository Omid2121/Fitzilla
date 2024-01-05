using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Fitzilla.Tests.Integration.Controllers
{
    public class WorkoutControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<Workout> Workouts { get; set; } = new();

        public WorkoutControllerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            Workouts = WorkoutSeedData.Workouts();
        }

        [Fact]
        public async Task GetWorkouts_Always_ReturnsAllWorkouts()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.WorkoutURL);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<Workout>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Name.Should().Be(Workouts[0].Name);
            result[0].Description.Should().Be(Workouts[0].Description);
            result[0].TargetMuscle.Should().Be(Workouts[0].TargetMuscle);
            result[0].CreationTime.Should().Be(Workouts[0].CreationTime);
            result[0].CreatorId.Should().Be(Workouts[0].CreatorId);
            result[0].Creator.Should().Be(Workouts[0].Creator);
        }

        [Fact]
        public async Task GetWorkout_WithValidId_ReturnsWorkout()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.WorkoutURL}{Workouts[0].Id}");
            var result = await response.Content.ReadFromJsonAsync<Workout>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Name.Should().Be(Workouts[0].Name);
            result.Description.Should().Be(Workouts[0].Description);
            result.TargetMuscle.Should().Be(Workouts[0].TargetMuscle);
            result.CreationTime.Should().Be(Workouts[0].CreationTime);
            result.CreatorId.Should().Be(Workouts[0].CreatorId);
            result.Creator.Should().Be(Workouts[0].Creator);
        }

        [Fact]
        public async Task GetWorkout_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.WorkoutURL}{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateWorkout_WithValidWorkout_ReturnsCreated()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(Workouts[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.WorkoutURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateWorkout_WithInvalidWorkout_ReturnsBadRequest()
        {
            // Arrange
            Workout invalidWorkout = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidWorkout), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.WorkoutURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateWorkout_WithValidWorkout_ReturnsNoContent()
        {
            // Arrange
            var updatedModel = new Workout()
            {
                Id = Workouts[0].Id,
                Name = "Updated Workout",
                Description = "Updated Workout description",
                TargetMuscle = TargetedMuscle.BACK,
                CreationTime = Workouts[0].CreationTime,
                LastModifiedTime = DateTime.Now,
                CreatorId = Workouts[0].CreatorId,
                Creator = Workouts[0].Creator,
                Exercises = Workouts[0].Exercises
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.WorkoutURL}{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateWorkout_WithInvalidWorkout_ReturnsBadRequest()
        {
            // Arrange
            var updatedModel = new Workout() { Id = Guid.Empty };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.WorkoutURL}{updatedModel.Id}", content);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteWorkout_WithValidId_ReturnsNoContent()
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.WorkoutURL}{Workouts[0].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteWorkout_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidId = Guid.Empty;

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.WorkoutURL}{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Search_WithValidQuery_ReturnsWorkouts()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.WorkoutURL}/search");
            var result = await response.Content.ReadFromJsonAsync<List<Workout>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Name.Should().Be(Workouts[0].Name);
            result[0].Description.Should().Be(Workouts[0].Description);
            result[0].TargetMuscle.Should().Be(Workouts[0].TargetMuscle);
            result[0].CreationTime.Should().Be(Workouts[0].CreationTime);
            result[0].CreatorId.Should().Be(Workouts[0].CreatorId);
            result[0].Creator.Should().Be(Workouts[0].Creator);
        }
    }
}
