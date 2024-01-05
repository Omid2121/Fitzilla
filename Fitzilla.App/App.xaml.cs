using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;

namespace Fitzilla.App
{
    public partial class App : Application
    {
        public static LoginResponseDTO CurrentUser { get; set; }
        public static string CurrentUserToken { get; set; }

        public static ExerciseTemplate CurrentExerciseType { get; set; }
        public static Exercise CurrentExercise { get; set; }
        public static Workout CurrentWorkout { get; set; }
        public static Macro CurrentMacro { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}