using Fitzilla.App.Services;
using Fitzilla.App.Views.Home;
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
    public partial class HeightViewModel : BaseViewModel
    {
        [ObservableProperty]
        private double _weight;

        private LoginViewModel _loginViewModel;

        public HeightViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        //TODO: Call RegisterAsync() from LoginViewModel to register user
        override public async void Continue()
        {
            Dictionary<string, object> data = new()
            {
                { "UserDTO", UserDTO }
            };

            var response = await _loginViewModel.RegisterAsync(UserDTO);

            //var response = await _loginViewModel.RegisterAsync();

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        override public void Previous()
        {
            base.Previous();
        }
    }
}
