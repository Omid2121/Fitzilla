using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using System.Net.Http.Json;

namespace Fitzilla.App.Services
{
    public class WorkoutService : IDataStore<WorkoutDTO, CreateWorkoutDTO>
    {
        private static readonly HttpClient HttpClient = new();
        private readonly string WorkoutURL =
            $"{IDataStore<WorkoutDTO, CreateWorkoutDTO>.API_URL}/{nameof(Workout)}";

        public async Task<bool> AddItemAsync(CreateWorkoutDTO item)
        {
            HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync(WorkoutURL, item);
            await Shell.Current.DisplayAlert("Success", await responseMessage.Content.ReadAsStringAsync(), "OK");
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage responseMessage = await HttpClient.DeleteAsync($"{WorkoutURL}/{id}");
            return responseMessage.IsSuccessStatusCode;
        }

        //TODO: Make sure HttpRequestMessage's URl is correct.
        public async Task<WorkoutDTO> GetItemAsync(string id) => (await RequestItemsAsync($"/{id}")).FirstOrDefault();

        public async Task<IEnumerable<WorkoutDTO>> GetItemsAsync(bool forceRefresh = false) => await RequestItemsAsync();

        public async Task<bool> UpdateItemAsync(WorkoutDTO item)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync($"{WorkoutURL}/{item.Id}", item);
            await Shell.Current.DisplayAlert("Success", await responseMessage.Content.ReadAsStringAsync(), "OK");
            return responseMessage.IsSuccessStatusCode;
        }

        private async Task<IEnumerable<WorkoutDTO>> RequestItemsAsync(string query = null)
        {
            HttpResponseMessage responseMessage = await HttpClient.GetAsync($"{WorkoutURL}{query}");
            if (!responseMessage.IsSuccessStatusCode) return null;

            return await responseMessage.Content.ReadFromJsonAsync<IEnumerable<WorkoutDTO>>();
        }
    }
}
