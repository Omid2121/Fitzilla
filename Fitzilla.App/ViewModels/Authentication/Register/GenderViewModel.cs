using Fitzilla.App.Views.Authentication;
using Fitzilla.App.Views.Authentication.Register;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Authentication.Register
{
    [QueryProperty(nameof(UserDTO), "UserDTO")]
    public partial class GenderViewModel : BaseViewModel
    {
        [ObservableProperty]
        string[] _genders = { "Male", "Female" };

        public GenderViewModel()
        {
        }

        public override async void Continue()
        {
            Dictionary<string, object> data = new()
            {
                { "UserDTO", UserDTO }
            };
            await Shell.Current.GoToAsync($"{nameof(AgePage)}", data);
        }

        public override async void Previous()
        {
            await Shell.Current.GoToAsync(nameof(LandingPage));
        }
    }
}
