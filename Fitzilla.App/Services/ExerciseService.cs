using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using System.Net.Http.Json;

namespace Fitzilla.App.Services
{
    public class ExerciseService : IDataStore<ExerciseDTO, CreateExerciseDTO>
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly string ExerciseURL =
            $"{IDataStore<ExerciseDTO, CreateExerciseDTO>.API_URL}/{nameof(Exercise)}";

        public async Task<bool> AddItemAsync(CreateExerciseDTO item)
        {
            HttpResponseMessage responseMessage = await HttpClient
                .PostAsJsonAsync(ExerciseURL, item);
            await Shell.Current.DisplayAlert("Success", await responseMessage.Content.ReadAsStringAsync(), "OK");
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage responseMessage = await HttpClient
                .DeleteAsync($"{ExerciseURL}?{id}");
            return responseMessage.IsSuccessStatusCode;
        }

        //TODO: Make sure HttpRequestMessage's URl is correct.
        public async Task<ExerciseDTO> GetItemAsync(string id) => (await RequestItemsAsync($"?{id}")).FirstOrDefault();

        public async Task<IEnumerable<ExerciseDTO>> GetItemsAsync(bool forceRefresh = false) => await RequestItemsAsync();

        public async Task<bool> UpdateItemAsync(ExerciseDTO item)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync($"{ExerciseURL}?{item.Id}", item);
            await Shell.Current.DisplayAlert("Success", await responseMessage.Content.ReadAsStringAsync(), "OK");
            return responseMessage.IsSuccessStatusCode;
        }

        private async Task<IEnumerable<ExerciseDTO>> RequestItemsAsync(string query = null)
        {
            HttpResponseMessage responseMessage = await HttpClient.GetAsync($"{ExerciseURL}{query}");
            if (!responseMessage.IsSuccessStatusCode) return null;

            return await responseMessage.Content.ReadFromJsonAsync<IEnumerable<ExerciseDTO>>();
        }
    }
}
