using Fitzilla.App.Services;
using Fitzilla.App.Views.Home;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Fitzilla.Data.Enums;
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
    public partial class WorkoutViewModel : BaseViewModel
    {
        [ObservableProperty]
        private WorkoutDTO _workout;

        [ObservableProperty]
        private ObservableCollection<WorkoutDTO> _workouts;

        [ObservableProperty]
        private TargetMuscle _targetMuscle;

        [ObservableProperty]
        private string _selectedMuscle;

        private readonly WorkoutService _workoutService;

        public WorkoutViewModel()
        {
            GetWorkouts();
        }

        [ICommand]
        public async void GetWorkouts()
        {
            try
            {
                Workouts = (ObservableCollection<WorkoutDTO>)await _workoutService.GetItemsAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        public async void AddWorkout()
        {
            if (!string.IsNullOrEmpty(Workout.Name))
            {
                await _workoutService.AddItemAsync(new WorkoutDTO
                {
                    Name = Workout.Name,
                    Note = Workout.Note,
                    TargetMuscle = TargetMuscle,
                    Exercises = Workout.Exercises,
                    User = App.CurrentUser,
                });
            }
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }

        [ICommand]
        public async void UpdateWorkout(WorkoutDTO workoutDTO)
        {
            if (!string.IsNullOrEmpty(workoutDTO.Id.ToString()))
            {
                await _workoutService.UpdateItemAsync(workoutDTO);
            }
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }

        [ICommand]
        public async void DeleteWorkout(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _workoutService.DeleteItemAsync(id);
            }
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
    }
}
