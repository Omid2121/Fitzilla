using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.ViewModels.Macro
{
    public partial class MacroViewModel
    {
        [ObservableProperty]
        private string[] _calorieConsume = { "Calorie Maintenance", "Calorie Surplus", "Calorie Deficit" };

        [ObservableProperty]
        private string[] _intencity = { "Sedentary", "Moderately active", "Very active" };

        private string selectedCalorieConsume = string.Empty;
        public string SelectedCalorieConsume
        {
            get => selectedCalorieConsume;
            set
            {
                selectedCalorieConsume = value;
                Calories = CalculateCalories();
            }
        }

        string selectedActivity = string.Empty;
        public string SelectedActivity
        {
            get => selectedActivity;
            set
            {
                selectedActivity = value;
                Calories = CalculateCalories();
            }
        }

        double bmr = 0;
        private double calories = 0;
        public double Calories
        {
            get => Math.Round(calories);
            set
            {
                calories = value;
                OnPropertyChanged(nameof(calories));
                OnPropertyChanged(nameof(Calories));
            }
        }

        public MacroViewModel()
        {
            
        }

        public double CalculateBMR(int age, string gender, float weight, float height)
        {
            if (gender == "Male")
                return bmr = weight * 10 + height * 6.25 - age * 5 - 5;
            else
                return bmr = weight * 10 + height * 6.25 - age * 5 - 161;
        }

        public double CalculateCalories()
        {
            double calories;

            if (SelectedActivity == "Sedentary")
                calories = bmr * 1.2;
            else if (SelectedActivity == "Moderately active")
                calories = bmr * 1.55;
            else
                calories = bmr * 1.725;


            if (SelectedCalorieConsume == "Calorie Maintenance")
                return calories;
            else if (SelectedCalorieConsume == "Calorie Surplus")
                return calories + 500;
            else
                return calories - 500;
        }
    }
}
