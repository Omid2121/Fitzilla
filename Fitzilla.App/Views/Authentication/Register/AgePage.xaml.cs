using Fitzilla.App.ViewModels.Authentication.Register;

namespace Fitzilla.App.Views.Authentication.Register;

public partial class AgePage : ContentPage
{
	public AgePage(AgeViewModel ageViewModel)
	{
		InitializeComponent();
		BindingContext = ageViewModel;
	}
}