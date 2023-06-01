using Fitzilla.App.Services;
using Fitzilla.App.Views.Exercises;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Exercises
{
    public partial class ExerciseTypeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ExerciseTypeDTO _exerciseType;

        [ObservableProperty]
        private ObservableCollection<ExerciseTypeDTO> _exerciseTypes;

        private readonly ExerciseTypeService _exerciseTypeService;

        public ExerciseTypeViewModel()
        {
            GetExerciseTypes();
        }

        [ICommand]
        public async void GetExerciseTypes()
        {
            try
            {
                ExerciseTypes = (ObservableCollection<ExerciseTypeDTO>)await _exerciseTypeService.GetItemsAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        public async void AddExerciseType()
        {
            if (!string.IsNullOrEmpty(ExerciseType.Name))
            {
                await _exerciseTypeService.AddItemAsync(new CreateExerciseTypeDTO
                {
                    Name = ExerciseType.Name
                });
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseTypePage)}");
        }

        [ICommand]
        public async void UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            if (!string.IsNullOrEmpty(exerciseTypeDTO.Id.ToString()))
            {
                await _exerciseTypeService.UpdateItemAsync(exerciseTypeDTO);
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseTypePage)}");
        }

        [ICommand]
        public async void DeleteExerciseType(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _exerciseTypeService.DeleteItemAsync(id);
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseTypePage)}");
        }
    }
}
