using Fitzilla.DAL.IRepository;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Fitzilla.BLL.Services;

public class MacroManager()
{

    public Macro CalculateMacroCycleLength(Macro macro, double currentWeight)
    {
        if (macro == null)
            throw new ArgumentNullException(nameof(macro), "Macro cannot be null.");

        if (currentWeight <= 0)
            throw new Exception("Current weight must be greater than zero.");

        if (macro.CycleStartDate < DateTimeOffset.Now)
            throw new Exception("Cycle start date cannot be in the past.");

        var weightDifference = Math.Abs(macro.GoalWeight - currentWeight);

        if (macro.GoalType != GoalType.Maintenance)
            macro.CycleEndDate = CalculateCycleEndDate(macro.CycleStartDate, weightDifference, macro.GoalType);

        return macro;
    }

    private static DateTimeOffset CalculateCycleEndDate(DateTimeOffset cycleStartDate, double weightDifference, GoalType goalType)
    {
        const double daysInWeek = 7;
        const double mildWeightLossOrGainMultiplier = 4;
        const double weightLossOrGainMultiplier = 2;
        const double extremeWeightLossOrGainMultiplier = 1;

        return goalType switch
        {
            GoalType.MildWeightLoss => cycleStartDate.AddDays(weightDifference * daysInWeek * mildWeightLossOrGainMultiplier),
            GoalType.WeightLoss => cycleStartDate.AddDays(weightDifference * daysInWeek * weightLossOrGainMultiplier),
            GoalType.ExtremeWeightLoss => cycleStartDate.AddDays(weightDifference * daysInWeek * extremeWeightLossOrGainMultiplier),
            GoalType.MildWeightGain => cycleStartDate.AddDays(weightDifference * daysInWeek * mildWeightLossOrGainMultiplier),
            GoalType.WeightGain => cycleStartDate.AddDays(weightDifference * daysInWeek * weightLossOrGainMultiplier),
            GoalType.ExtremeWeightGain => cycleStartDate.AddDays(weightDifference * daysInWeek * extremeWeightLossOrGainMultiplier),
            _ => throw new Exception("Invalid goal type."),
        };
    }

    public Macro? CalculateMacro(Macro macro, User user)
    {
        macro.NutritionInfo.Calorie = CalculateBMR(user);
        macro.NutritionInfo.Calorie = CalculateActivityLevel(macro);
        macro.NutritionInfo.Calorie = CalculateGoalType(macro);

        // User's macros (Protein, Carbs, Fat)
        if (!IsValidMacroPercentage(macro.NutritionInfo))
            throw new Exception("Macro percentages should add up to 100%");

        // 1 gram of protein = 4 calories
        macro.NutritionInfo.ProteinAmount = macro.NutritionInfo.Calorie * (macro.NutritionInfo.ProteinPercentage / 100) / 4;
        // 1 gram of carbs = 4 calories
        macro.NutritionInfo.CarbohydrateAmount = macro.NutritionInfo.Calorie * (macro.NutritionInfo.CarbohydratePercentage / 100) / 4;
        // 1 gram of fat = 9 calories
        macro.NutritionInfo.FatAmount = macro.NutritionInfo.Calorie * (macro.NutritionInfo.FatPercentage / 100) / 9;

        return macro;
    }

    private static double CalculateBMR(User user)
    {
        int age = DateTime.Now.Year - user.DateOfBirth.Year;

        if (user.Gender == Gender.Male)
        {
            return (10 * user.Weight) + (6.25 * user.Height) - (5 * age) + 5;
        }
        else
        {
            return (10 * user.Weight) + (6.25 * user.Height) - (5 * age) - 161;
        }
    }

    private static double CalculateActivityLevel(Macro macro)
    {
        return macro.ActivityLevel switch
        {
            ActivityLevel.Sedentary => macro.NutritionInfo.Calorie *= 1.2,
            ActivityLevel.LightlyActive => macro.NutritionInfo.Calorie *= 1.375,
            ActivityLevel.ModeratelyActive => macro.NutritionInfo.Calorie *= 1.55,
            ActivityLevel.VigorouslyActive => macro.NutritionInfo.Calorie *= 1.725,
            ActivityLevel.VeryActive => macro.NutritionInfo.Calorie *= 1.9,
            _ => throw new Exception("Invalid activity level."),
        };
    }

    private static double CalculateGoalType(Macro macro)
    {
        return macro.GoalType switch
        {
            GoalType.MildWeightLoss => macro.NutritionInfo.Calorie -= 250,
            GoalType.WeightLoss => macro.NutritionInfo.Calorie -= 500,
            GoalType.ExtremeWeightLoss => macro.NutritionInfo.Calorie -= 1000,
            GoalType.Maintenance => macro.NutritionInfo.Calorie,
            GoalType.MildWeightGain => macro.NutritionInfo.Calorie += 250,
            GoalType.WeightGain => macro.NutritionInfo.Calorie += 500,
            GoalType.ExtremeWeightGain => macro.NutritionInfo.Calorie += 1000,
            _ => throw new Exception("Invalid goal type."),
        };
    }

    private static bool IsValidMacroPercentage(NutritionInfo nutritionInfo)
    {
        return Math.Abs(nutritionInfo.ProteinPercentage + nutritionInfo.CarbohydratePercentage + nutritionInfo.FatPercentage) == 100;
    }

}
