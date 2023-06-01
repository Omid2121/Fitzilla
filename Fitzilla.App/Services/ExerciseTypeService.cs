using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Fitzilla.App.Services
{
    public class ExerciseTypeService : IDataStore<ExerciseTypeDTO, CreateExerciseTypeDTO>
    {
        private static readonly HttpClient HttpClient = new();
        private readonly string ExerciseTypeURL = 
            $"{IDataStore<ExerciseTypeDTO, CreateExerciseTypeDTO>.API_URL}/{nameof(ExerciseType)}";

        public async Task<bool> AddItemAsync(CreateExerciseTypeDTO item)
        {
            HttpResponseMessage httpResponseMessage = await HttpClient
                .PostAsJsonAsync(ExerciseTypeURL, item);
            await Shell.Current.DisplayAlert("Success", await httpResponseMessage.Content.ReadAsStringAsync(), "OK");
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage httpResponseMessage = await HttpClient
                .DeleteAsync($"{ExerciseTypeURL}?{id}");
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<ExerciseTypeDTO> GetItemAsync(string id)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            return (await RequestItemsAsync($"?{id}")).FirstOrDefault();
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> GetItemsAsync(bool forceRefresh = false) => await RequestItemsAsync();

        public async Task<bool> UpdateItemAsync(ExerciseTypeDTO item)
        {
            //TODO: Make sure HttpRequestMessage's URl is correct.
            HttpResponseMessage httpRequestMessage = await HttpClient
                .PutAsJsonAsync($"{ExerciseTypeURL}?{item.Id}", item);
            await Shell.Current.DisplayAlert("Success", await httpRequestMessage.Content.ReadAsStringAsync(), "OK");
            return httpRequestMessage.IsSuccessStatusCode;
        }

        private async Task<IEnumerable<ExerciseTypeDTO>> RequestItemsAsync(string query = null)
        {
            var responseInJson = await HttpClient.GetAsync($"{ExerciseTypeURL}{query}");
            if (!responseInJson.IsSuccessStatusCode) return null;

            return await responseInJson.Content.ReadFromJsonAsync<IEnumerable<ExerciseTypeDTO>>();
        }
    }
}
