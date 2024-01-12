using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.DAL.DTOs;
using Fitzilla.DAL.Repository;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Http.Json;
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
    public class ExerciseTemplatesControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<ExerciseTemplate> ExerciseTemplates { get; set; } = new();
        public ExerciseTemplatesControllerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            ExerciseTemplates = ExerciseTemplateSeedData.ExerciseTemplates();
        }

        [Fact]
        public async Task GetExerciseTemplates_Always_ReturnsAllExerciseTemplates()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.ExerciseTemplateURL);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<ExerciseTemplate>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Title.Should().Be(ExerciseTemplates[0].Title);
            result[0].Description.Should().Be(ExerciseTemplates[0].Description);
            result[0].Image.Should().Be(ExerciseTemplates[0].Image);
            result[0].CreatedAt.Should().Be(ExerciseTemplates[0].CreatedAt);
        }

        [Fact]
        public async Task GetExerciseTemplate_WithValidId_ReturnsExerciseTemplate()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{ExerciseTemplates[0].Id}");
            var result = await response.Content.ReadFromJsonAsync<ExerciseTemplate>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Title.Should().Be(ExerciseTemplates[0].Title);
            result.Description.Should().Be(ExerciseTemplates[0].Description);
            result.Image.Should().Be(ExerciseTemplates[0].Image);
            result.CreatedAt.Should().Be(ExerciseTemplates[0].CreatedAt);
        }

        [Fact]
        public async Task GetExerciseTemplate_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidId = Guid.Empty;

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateExerciseTemplate_WithValidExerciseTemplate_ReturnsCreated()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(ExerciseTemplates[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.ExerciseTemplateURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateExerciseTemplate_WithInvalidExerciseTemplate_ReturnsBadRequest()
        {
            // Arrange
            ExerciseTemplate invalidExerciseTemplate = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidExerciseTemplate), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.ExerciseURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateExerciseTemplate_WithValidExerciseTemplate_ReturnsNoContent()
        {
            // Arrange
            ExerciseTemplate updatedModel = new()
            {
                Id = ExerciseTemplates[0].Id,
                Title = "Updated ExerciseTemplate",
                Description = "Updated ExerciseTemplate description",
                Image = "updatedimage.png",
                CreatedAt = DateTime.Now,
            };
            

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateExerciseTemplate_WithInvalidExerciseTemplate_ReturnsBadRequest()
        {
            // Arrange
            ExerciseTemplate updatedModel = new() { Id = Guid.Empty };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{updatedModel.Id}", content);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteExerciseTemplate_WithValidId_ReturnsNoContent()
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{ExerciseTemplates[0].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteExerciseTemplate_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var exerciseTemplateId = Guid.Empty;

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{exerciseTemplateId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Search_WithValidQuery_ReturnsExerciseTemplates()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.ExerciseTemplateURL}/search");
            var result = await response.Content.ReadFromJsonAsync<List<ExerciseTemplate>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Title.Should().Be(ExerciseTemplates[0].Title);
            result[0].Description.Should().Be(ExerciseTemplates[0].Description);
            result[0].Image.Should().Be(ExerciseTemplates[0].Image);
            result[0].CreatedAt.Should().Be(ExerciseTemplates[0].CreatedAt);
        }
    }
}
