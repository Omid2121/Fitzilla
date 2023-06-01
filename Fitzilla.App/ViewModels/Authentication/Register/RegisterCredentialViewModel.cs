using Fitzilla.App.Views.Authentication.Register;
using System.Text.RegularExpressions;

namespace Fitzilla.App.ViewModels.Authentication.Register
{
    public partial class RegisterCredentialViewModel : BaseViewModel
    {
        public RegisterCredentialViewModel()
        {
        }

        override public async void Continue()
        {
            try
            {
                if (!ValidateEmail() || !ValidatePwd())
                {
                    await Shell.Current.GoToAsync($"{nameof(RegisterCredentialPage)}");
                    return;
                }

                Dictionary<string, object> data = new()
                {
                    { "UserDTO", UserDTO }
                };
                await Shell.Current.GoToAsync($"{nameof(GenderPage)}", data);
            }
            catch (Exception)
            {
                await Shell.Current.GoToAsync($"{nameof(RegisterCredentialPage)}");
            }
        }

        override public void Previous()
        {
            base.Previous();
        }

        private bool ValidateEmail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(UserDTO.Email);
            bool IsValid = match.Success;
            return IsValid;
        }

        private bool ValidatePwd()
        {
            bool IsValid = !string.IsNullOrEmpty(UserDTO.Password);
            return IsValid;
        }
    }
}
