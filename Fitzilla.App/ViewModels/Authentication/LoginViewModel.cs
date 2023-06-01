using __XamlGeneratedCode__;
using Fitzilla.App.Services;
using Fitzilla.App.Views.Authentication.Register;
using Fitzilla.App.Views.Home;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Authentication
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private LoginUserDTO _loginUserDTO;

        private readonly ILoginService _loginService;

        public LoginViewModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        [ICommand]
        public async void LoginAsync()
        {
            if (!string.IsNullOrEmpty(_loginUserDTO.Email) && !string.IsNullOrEmpty(_loginUserDTO.Password))
            {
                var response = await _loginService.LoginAsync(_loginUserDTO);

                if (response == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Invalid username or password", "Ok");
                }

                if (Preferences.ContainsKey(nameof(App.CurrentUser)))
                {
                    Preferences.Remove(nameof(App.CurrentUser));
                }

                await SecureStorage.SetAsync(nameof(App.CurrentUserToken), response.Token);

                string userJson = JsonConvert.SerializeObject(response);
                Preferences.Set(nameof(App.CurrentUser), userJson);
                App.CurrentUser = response;

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }

        [ICommand]
        public async void RegisterAsync(UserDTO userDTO)
        {
            if (!string.IsNullOrEmpty(userDTO.Email) && !string.IsNullOrEmpty(userDTO.Password))
            {
                var response = await _loginService.RegisterAsync(userDTO);

                if (response == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Invalid data", "Ok");
                }

                if (Preferences.ContainsKey(nameof(App.CurrentUser)))
                {
                    Preferences.Remove(nameof(App.CurrentUser));
                }

                await SecureStorage.SetAsync(nameof(App.CurrentUserToken), response.Token);

                string userJson = JsonConvert.SerializeObject(response);
                Preferences.Set(nameof(App.CurrentUser), userJson);
                App.CurrentUser = response;

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }

        public override async void Continue()
        {
            await Shell.Current.GoToAsync(nameof(RegisterCredentialPage));
        }

        public override void Previous()
        {
            base.Previous();
        }
    }
}
