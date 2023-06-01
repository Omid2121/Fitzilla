using Fitzilla.App.ViewModels.Home;

namespace Fitzilla.App.Views.Home;

public partial class HomePage : ContentPage
{
	public HomePage(MarcoViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
	}
}