using Fitzilla.App.ViewModels.Profile;

namespace Fitzilla.App.Views.Profile;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
}