using Fitzilla.App.Views.Authentication;
using Fitzilla.App.Views.Profile;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Profile
{
    public partial class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            
        }

        [ICommand]
        public async void About() => await Shell.Current.GoToAsync($"{nameof(AboutPage)}");

        [ICommand]
        public async void MyWorkouts() => await Shell.Current.GoToAsync($"{nameof(MyWorkoutsPage)}");
        
        [ICommand]  
        public async void MyMacros() => await Shell.Current.GoToAsync($"{nameof(MyMacrosPage)}");
        
        [ICommand]
        public async void MySteps() => await Shell.Current.GoToAsync($"{nameof(MyStepsPage)}");

        [ICommand]
        public async void Settings() => await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");

        [ICommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.CurrentUser)))
            {
                Preferences.Remove(nameof(App.CurrentUser));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
