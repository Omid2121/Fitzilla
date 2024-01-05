using Fitzilla.App.Services;
using Fitzilla.App.Views.Exercises;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Fitzilla.App.ViewModels.Exercises
{
    public partial class ExerciseViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ExerciseDTO _exercise;

        [ObservableProperty]
        private ObservableCollection<ExerciseDTO> _exercises;

        private readonly ExerciseService _exerciseService;

        public ExerciseViewModel()
        {
            GetExercises();
        }

        [ICommand]
        public async void GetExercises()
        {
            try
            {
                Exercises = (ObservableCollection<ExerciseDTO>)await _exerciseService.GetItemsAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        public async void AddExercise()
        {
            if (!string.IsNullOrEmpty(Exercise.ExerciseType.Name))
            {
                await _exerciseService.AddItemAsync(new CreateExerciseDTO
                {
                    ExerciseTypeId = Exercise.ExerciseType.Id,

                });
            }
            await Shell.Current.GoToAsync($"{nameof(ExercisePage)}");
        }

        [ICommand]
        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            if (!string.IsNullOrEmpty(exerciseDTO.Id.ToString()))
            {
                await _exerciseService.UpdateItemAsync(exerciseDTO);
            }
            await Shell.Current.GoToAsync($"{nameof(ExercisePage)}");
        }

        [ICommand]
        public async void DeleteExercise(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _exerciseService.DeleteItemAsync(id);
            }
            await Shell.Current.GoToAsync($"{nameof(ExercisePage)}");
        }
    }
}
