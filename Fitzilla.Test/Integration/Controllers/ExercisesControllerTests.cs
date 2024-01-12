using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.DAL.DTOs;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Fitzilla.Tests.Integration.Controllers
{
    public class ExercisesControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<Exercise> Exercises { get; set; } = new();

        public ExercisesControllerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            Exercises = ExerciseSeedData.Exercises();
        }

        [Fact]
        public async Task GetExercises_Always_ReturnsAllExercises()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.ExerciseURL);
            var result = await response.Content.ReadFromJsonAsync<List<Exercise>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Title.Should().Be(Exercises[0].Title);
            result[0].Description.Should().Be(Exercises[0].Description);
            result[0].Image.Should().Be(Exercises[0].Image);
            result[0].Set.Should().Be(Exercises[0].Set);
            result[0].Rep.Should().Be(Exercises[0].Rep);
            result[0].Weight.Should().Be(Exercises[0].Weight);
            result[0].CreatedAt.Should().Be(Exercises[0].CreatedAt);
            result[0].CreatorId.Should().Be(Exercises[0].CreatorId);
            result[0].Creator.Should().Be(Exercises[0].Creator);
        }

        [Fact]
        public async Task GetExercise_WithValidId_ReturnsExercise()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.ExerciseURL}{Exercises[0].Id}");
            var result = await response.Content.ReadFromJsonAsync<Exercise>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Title.Should().Be(Exercises[0].Title);
            result.Description.Should().Be(Exercises[0].Description);
            result.Image.Should().Be(Exercises[0].Image);
            result.Set.Should().Be(Exercises[0].Set);
            result.Rep.Should().Be(Exercises[0].Rep);
            result.Weight.Should().Be(Exercises[0].Weight);
            result.CreatedAt.Should().Be(Exercises[0].CreatedAt);
            result.CreatorId.Should().Be(Exercises[0].CreatorId);
            result.Creator.Should().Be(Exercises[0].Creator);
        }

        [Fact]
        public async Task GetExercise_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidExerciseId = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.ExerciseURL}{invalidExerciseId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateExercise_WithValidExercise_ReturnsCreated()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(Exercises[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.ExerciseURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateExercise_WithInvalidExercise_ReturnsBadRequest()
        {
            // Arrange
            Exercise invalidExercise = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidExercise), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.ExerciseURL, content);
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateExercise_WithValidExercise_ReturnsNoContent()
        {
            // Arrange
            var updatedModel = new Exercise()
            {
                Id = Exercises[0].Id,
                Title = "Updated Exercise",
                Description = "Updated Exercise Description",
                Image = "Updatedimage.png",
                Set = 2,
                Rep = 10,
                Weight = 100,
                CreatedAt = DateTime.Now,
                CreatorId = Exercises[0].CreatorId,
                Creator = Exercises[0].Creator
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.ExerciseURL}{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateExercise_WithInvalidExercise_ReturnsBadRequest()
        {
            // Arrange
            var updatedModel = new Exercise() { Id = Guid.Empty };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.ExerciseURL}{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteExercise_WithValidId_ReturnsNoContent()
        {
            // Arrange
            
            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.ExerciseURL}{Exercises[0].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteExercise_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var exerciseId = Guid.Empty;

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.ExerciseURL}{exerciseId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Search_WithValidQuery_ReturnsExercises()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.ExerciseURL);
            var result = await response.Content.ReadFromJsonAsync<List<Exercise>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Title.Should().Be(Exercises[0].Title);
            result[0].Description.Should().Be(Exercises[0].Description);
            result[0].Image.Should().Be(Exercises[0].Image);
            result[0].Set.Should().Be(Exercises[0].Set);
            result[0].Rep.Should().Be(Exercises[0].Rep);
            result[0].Weight.Should().Be(Exercises[0].Weight);
            result[0].CreatedAt.Should().Be(Exercises[0].CreatedAt);
            result[0].CreatorId.Should().Be(Exercises[0].CreatorId);
            result[0].Creator.Should().Be(Exercises[0].Creator);
        }
    }
}
