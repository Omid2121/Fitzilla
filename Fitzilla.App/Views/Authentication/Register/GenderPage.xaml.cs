using Fitzilla.App.ViewModels.Authentication.Register;

namespace Fitzilla.App.Views.Authentication.Register;

public partial class GenderPage : ContentPage
{
	public GenderPage(GenderViewModel genderViewModel)
	{
		InitializeComponent();
		BindingContext = genderViewModel;
	}
}