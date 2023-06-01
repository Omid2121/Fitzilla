using Fitzilla.Core.DTOs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Fitzilla.App.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private string _title;

        public UserDTO UserDTO { get; set; }


        [ICommand]
        public virtual async void Continue()
        {
            throw new NotImplementedException();
        }

        [ICommand]
        public virtual async void Previous()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
