using Fitzilla.App.ViewModels.Authentication.Register;

namespace Fitzilla.App.Views.Authentication.Register;

public partial class RegisterCredentialPage : ContentPage
{
	public RegisterCredentialPage(RegisterCredentialViewModel registerCredentialViewModel)
	{
		InitializeComponent();
		BindingContext = registerCredentialViewModel;
	}
}