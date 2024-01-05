using Fitzilla.App.ViewModels;
using Fitzilla.App.Views.Authentication;
using Fitzilla.App.Views.Authentication.Register;
using Fitzilla.App.Views.Exercises;
using Fitzilla.App.Views.Home;
using Fitzilla.App.Views.Macro;
using Fitzilla.App.Views.Plus;
using Fitzilla.App.Views.Profile;

namespace Fitzilla.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = new AppShellViewModel();
            
            Routing.RegisterRoute(nameof(AgePage), typeof(AgePage));
            Routing.RegisterRoute(nameof(GenderPage), typeof(GenderPage));
            Routing.RegisterRoute(nameof(HeightPage), typeof(HeightPage));
            Routing.RegisterRoute(nameof(RegisterCredentialPage), typeof(RegisterCredentialPage));
            Routing.RegisterRoute(nameof(WeightPage), typeof(WeightPage));
            Routing.RegisterRoute(nameof(LandingPage), typeof(LandingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
            Routing.RegisterRoute(nameof(ExerciseTypePage), typeof(ExerciseTypePage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(MacroPage), typeof(MacroPage));
            Routing.RegisterRoute(nameof(PlusPage), typeof(PlusPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }
    }
}