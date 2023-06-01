using Fitzilla.App.ViewModels.Authentication.Register;

namespace Fitzilla.App.Views.Authentication.Register;

public partial class WeightPage : ContentPage
{
	public WeightPage(WeightViewModel weightViewModel)
	{
		InitializeComponent();
		BindingContext = weightViewModel;
	}
}