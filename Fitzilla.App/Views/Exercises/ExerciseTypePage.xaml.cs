using Fitzilla.App.ViewModels.Exercises;

namespace Fitzilla.App.Views.Exercises;

public partial class ExerciseTypePage : ContentPage
{
	public ExerciseTypePage(ExerciseTypeViewModel exerciseTypeViewModel)
	{
		InitializeComponent();
		BindingContext = exerciseTypeViewModel;
	}
}