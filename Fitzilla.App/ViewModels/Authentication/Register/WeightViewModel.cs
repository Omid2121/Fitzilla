using Fitzilla.App.Views.Authentication.Register;
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
    public partial class WeightViewModel : BaseViewModel
    {
        [ObservableProperty]
        private double _weight;

        public WeightViewModel()
        {
        }

        override public async void Continue()
        {
            Dictionary<string, object> data = new()
            {
                { "UserDTO", UserDTO }
            };
            await Shell.Current.GoToAsync($"{nameof(HeightPage)}", data);
        }

        override public void Previous()
        {
            base.Previous();
        }
    }
}
