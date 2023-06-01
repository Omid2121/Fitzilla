using Fitzilla.App.ViewModels.Exercises;

namespace Fitzilla.App.Views.Exercises;

public partial class ExercisePage : ContentPage
{
	public ExercisePage(ExerciseViewModel exerciseViewModel)
	{
		InitializeComponent();
		BindingContext = exerciseViewModel;
	}
}