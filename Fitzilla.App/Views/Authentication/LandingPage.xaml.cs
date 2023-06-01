using Fitzilla.App.ViewModels.Authentication;

namespace Fitzilla.App.Views.Authentication;

public partial class LandingPage : ContentPage
{
	public LandingPage(LandingViewModel landingViewModel)
	{
		InitializeComponent();
		BindingContext = landingViewModel;
	}
}