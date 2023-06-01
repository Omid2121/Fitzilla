using Fitzilla.App.ViewModels.Authentication.Register;

namespace Fitzilla.App.Views.Authentication.Register;

public partial class HeightPage : ContentPage
{
	public HeightPage()
	{
		InitializeComponent();
		BindingContext = new HeightViewModel();
	}
}