using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using X.PagedList;

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
        macro.Calorie = CalculateBMR(user);
        macro.Calorie = CalculateActivityLevel(macro);
        macro.Calorie = CalculateGoalType(macro);

        // User's macros (Protein, Carbs, Fat)
        if (!IsValidMacroPercentage(macro))
            throw new Exception("Macro percentages should add up to 100%");

        // 1 gram of protein = 4 calories
        macro.ProteinAmount = macro.Calorie * (macro.ProteinPercentage / 100) / 4;
        // 1 gram of carbs = 4 calories
        macro.CarbohydrateAmount = macro.Calorie * (macro.CarbohydratePercentage / 100) / 4;
        // 1 gram of fat = 9 calories
        macro.FatAmount = macro.Calorie * (macro.FatPercentage / 100) / 9;

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
            ActivityLevel.Sedentary => macro.Calorie *= 1.2,
            ActivityLevel.LightlyActive => macro.Calorie *= 1.375,
            ActivityLevel.ModeratelyActive => macro.Calorie *= 1.55,
            ActivityLevel.VigorouslyActive => macro.Calorie *= 1.725,
            ActivityLevel.VeryActive => macro.Calorie *= 1.9,
            _ => throw new Exception("Invalid activity level."),
        };
    }

    private static double CalculateGoalType(Macro macro)
    {
        return macro.GoalType switch
        {
            GoalType.MildWeightLoss => macro.Calorie -= 250,
            GoalType.WeightLoss => macro.Calorie -= 500,
            GoalType.ExtremeWeightLoss => macro.Calorie -= 1000,
            GoalType.Maintenance => macro.Calorie,
            GoalType.MildWeightGain => macro.Calorie += 250,
            GoalType.WeightGain => macro.Calorie += 500,
            GoalType.ExtremeWeightGain => macro.Calorie += 1000,
            _ => throw new Exception("Invalid goal type."),
        };
    }

    private static bool IsValidMacroPercentage(Macro macro)
    {
        return Math.Abs(macro.ProteinPercentage + macro.CarbohydratePercentage + macro.FatPercentage) == 100;
    }
    
    public IOrderedQueryable<Macro> SortMacrosByOptions(SortOption sortOption, IQueryable<Macro> macros)
    {
        return sortOption switch
        {
            SortOption.Alphabetical => macros.OrderBy(macro => macro.Title),
            SortOption.ReverseAlphabetical => macros.OrderByDescending(macro => macro.Title),
            SortOption.MostRecent => macros.OrderByDescending(macro => macro.CreatedAt),
            SortOption.Oldest => macros.OrderBy(macro => macro.CreatedAt),
            _ => macros.OrderBy(macro => macro.Title),
        };
    }

    public IPagedList<Macro> FilterMacrosByQuery(MacroFilterQuery filterQuery, IPagedList<Macro> macros)
    {
        if (filterQuery.goalTypes.Count > 0)
        {
            macros = (IPagedList<Macro>)macros.Where(
                m => filterQuery.goalTypes.Contains(m.GoalType)).ToList();
        }

        if (filterQuery.ActivityLevels.Count > 0)
        {
            macros = (IPagedList<Macro>)macros.Where(
                m => filterQuery.ActivityLevels.Contains(m.ActivityLevel)).ToList();
        }
        return macros;
    }

}
