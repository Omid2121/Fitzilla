using Fitzilla.App.ViewModels.Plus;

namespace Fitzilla.App.Views.Plus;

public partial class PlusPage : ContentPage
{
	public PlusPage(WorkoutsViewModel plusViewModel)
	{
		InitializeComponent();
		BindingContext = plusViewModel;
	}
}