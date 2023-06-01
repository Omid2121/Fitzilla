using Fitzilla.App.ViewModels.Authentication;

namespace Fitzilla.App.Views.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}