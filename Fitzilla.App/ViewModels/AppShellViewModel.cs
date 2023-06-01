using Fitzilla.App.Views.Authentication;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel<object>
    {
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
