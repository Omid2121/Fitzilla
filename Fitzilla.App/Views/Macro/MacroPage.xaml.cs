using Fitzilla.App.ViewModels.Macro;

namespace Fitzilla.App.Views.Macro;

public partial class MacroPage : ContentPage
{
	public MacroPage(MacroViewModel macroViewModel)
	{
		InitializeComponent();
		BindingContext = macroViewModel;
	}
}