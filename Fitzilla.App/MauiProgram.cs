using Fitzilla.App.Services;
using Fitzilla.App.ViewModels.Authentication;
using Fitzilla.App.ViewModels.Authentication.Register;
using Fitzilla.App.ViewModels.Exercises;
using Fitzilla.App.ViewModels.Home;
using Fitzilla.App.ViewModels.Profile;

namespace Fitzilla.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Services
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<ExerciseTypeService>();
            builder.Services.AddSingleton<ExerciseService>();
            builder.Services.AddSingleton<WorkoutService>();

            //ViewModels
            builder.Services.AddSingleton<LandingViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterCredentialViewModel>();
            builder.Services.AddSingleton<AgeViewModel>();
            builder.Services.AddSingleton<GenderViewModel>();
            builder.Services.AddSingleton<HeightViewModel>();
            builder.Services.AddSingleton<WeightViewModel>();
            builder.Services.AddSingleton<ExerciseTypeViewModel>();
            builder.Services.AddSingleton<ExerciseViewModel>();
            builder.Services.AddSingleton<WorkoutViewModel>();
            builder.Services.AddSingleton<MarcoViewModel>();
            builder.Services.AddSingleton<MarcoViewModel>();
            builder.Services.AddSingleton<ProfileViewModel>();


            return builder.Build();
        }
    }
}