using Fitzilla.App.Views.Authentication;
using Fitzilla.App.Views.Authentication.Register;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Authentication
{
    public partial class LandingViewModel
    {
        [ICommand]
        public async void Login()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        [ICommand]
        public async void Register()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterCredentialPage)}");
        }
    }
}
