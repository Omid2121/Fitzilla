using Fitzilla.DAL.Configurations.SeedData;
using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Newtonsoft.Json;
using Fitzilla.Models.Enums;

namespace Fitzilla.Tests.Integration.Controllers
{
    public class MacroControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<Macro> Macros { get; set; } = new();
        public MacroControllerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            Macros = MacroSeedData.Macros();
        }

        [Fact]
        public async Task GetMacros_Always_ReturnsAllMacros()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.MacroURL);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<Macro>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Name.Should().Be(Macros[0].Name);
            result[0].ConsumeType.Should().Be(Macros[0].ConsumeType);
            result[0].Intensity.Should().Be(Macros[0].Intensity);
            result[0].Calorie.Should().Be(Macros[0].Calorie);
            result[0].Protein.Should().Be(Macros[0].Protein);
            result[0].Carbohydrate.Should().Be(Macros[0].Carbohydrate);
            result[0].Fat.Should().Be(Macros[0].Fat);
            result[0].CreationTime.Should().Be(Macros[0].CreationTime);
            result[0].LastModifiedTime.Should().Be(Macros[0].LastModifiedTime);
            result[0].CreatorId.Should().Be(Macros[0].CreatorId);
            result[0].Creator.Should().Be(Macros[0].Creator);
            
        }

        [Fact]
        public async Task GetMacro_WithValidId_ReturnsMacro()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.MacroURL}{Macros[0].Id}");
            var result = await response.Content.ReadFromJsonAsync<Macro>();
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Name.Should().Be(Macros[0].Name);
            result.ConsumeType.Should().Be(Macros[0].ConsumeType);
            result.Intensity.Should().Be(Macros[0].Intensity);
            result.Calorie.Should().Be(Macros[0].Calorie);
            result.Protein.Should().Be(Macros[0].Protein);
            result.Carbohydrate.Should().Be(Macros[0].Carbohydrate);
            result.Fat.Should().Be(Macros[0].Fat);
            result.CreationTime.Should().Be(Macros[0].CreationTime);
            result.LastModifiedTime.Should().Be(Macros[0].LastModifiedTime);
            result.CreatorId.Should().Be(Macros[0].CreatorId);
            result.Creator.Should().Be(Macros[0].Creator);
        }

        [Fact]
        public async Task GetMacro_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidId = Guid.Empty;

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.MacroURL}{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateMacro_WithValidMacro_ReturnsCreated()
        {
            // Arrange

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(Macros[0]), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.MacroURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateMacro_WithInvalidMacro_ReturnsBadRequest()
        {
            // Arrange
            ExerciseTemplate invalidMacro = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(invalidMacro), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.MacroURL, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateMacro_WithValidMacro_ReturnsNoContent()
        {
            // Arrange
            Macro updatedModel = new()
            {
                Id = Macros[0].Id,
                ConsumeType = ConsumeType.DEFICIT,
                Intensity = Intensity.VERY_ACTIVE,
                Calorie = 2000,
                Protein = 200,
                Carbohydrate = 200,
                Fat = 200,
                CreationTime = Macros[0].CreationTime,
                LastModifiedTime = Macros[0].LastModifiedTime,
                CreatorId = Macros[0].CreatorId,
                Creator = Macros[0].Creator
            };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.MacroURL}{updatedModel.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateMacro_WithInvalidMacro_ReturnsBadRequest()
        {
            // Arrange
            Macro updatedModel = new() { Id = Guid.Empty };

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(updatedModel), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.ExerciseTemplateURL}{updatedModel.Id}", content);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteMacro_WithValidId_ReturnsNoContent()
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.MacroURL}{Macros[0].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteMacro_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var invalidId = Guid.Empty;

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.MacroURL}{invalidId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Search_WithValidQuery_ReturnsMacros()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.MacroURL}/search");
            var result = await response.Content.ReadFromJsonAsync<List<Macro>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Name.Should().Be(Macros[0].Name);
            result[0].ConsumeType.Should().Be(Macros[0].ConsumeType);
            result[0].Intensity.Should().Be(Macros[0].Intensity);
            result[0].Calorie.Should().Be(Macros[0].Calorie);
            result[0].Protein.Should().Be(Macros[0].Protein);
            result[0].Carbohydrate.Should().Be(Macros[0].Carbohydrate);
            result[0].Fat.Should().Be(Macros[0].Fat);
            result[0].CreationTime.Should().Be(Macros[0].CreationTime);
            result[0].LastModifiedTime.Should().Be(Macros[0].LastModifiedTime);
            result[0].CreatorId.Should().Be(Macros[0].CreatorId);
            result[0].Creator.Should().Be(Macros[0].Creator);
        }
    }
}
