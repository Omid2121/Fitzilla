using Fitzilla.DAL.IRepository;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Fitzilla.BLL.Services;

public class MacroManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public MacroManager(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public Macro? CalculateMacros(Macro macro, User user)
    {
        macro.Calorie = CalculateBMR(user);
        macro.Calorie = CalculateActivityLevel(macro);
        macro.Calorie = CalculateGoalType(macro);

        // User's macros (Protein, Carbs, Fat)
        if (!IsValidMacroPercentage(macro.ProteinPercentage, macro.CarbohydratePercentage, macro.FatPercentage))
            throw new Exception("Macro percentages should add up to 100%");

        macro.ProteinAmount = macro.Calorie * (macro.ProteinPercentage / 100) / 4;
        macro.CarbohydrateAmount = macro.Calorie * (macro.CarbohydratePercentage / 100) / 4;
        macro.FatAmount = macro.Calorie * (macro.FatPercentage / 100) / 9;

        return macro;
    }

    private double CalculateBMR(User user)
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

    private double CalculateActivityLevel(Macro macro)
    {
        switch (macro.ActivityLevel)
        {
            case ActivityLevel.Sedentary:
                macro.Calorie *= 1.2;
                break;
            case ActivityLevel.LightlyActive:
                macro.Calorie *= 1.375;
                break;
            case ActivityLevel.ModeratelyActive:
                macro.Calorie *= 1.55;
                break;
            case ActivityLevel.VigorouslyActive:
                macro.Calorie *= 1.725;
                break;
            case ActivityLevel.VeryActive:
                macro.Calorie *= 1.9;
                break;
            default:
                break;
        }
        return macro.Calorie;
    }

    private double CalculateGoalType(Macro macro)
    {
        switch (macro.GoalType)
        {
            case GoalType.MildWeightLoss:
                macro.Calorie -= 250;
                break;
            case GoalType.WeightLoss:
                macro.Calorie -= 500;
                break;
            case GoalType.ExtremeWeightLoss:
                macro.Calorie -= 1000;
                break;
            case GoalType.Maintenance:
                break;
            case GoalType.MildWeightGain:
                macro.Calorie += 250;
                break;
            case GoalType.WeightGain:
                macro.Calorie += 500;
                break;
            case GoalType.ExtremeWeightGain:
                macro.Calorie += 1000;
                break;
            default:
                break;
        }
        return macro.Calorie;
    }

    private bool IsValidMacroPercentage(int proteinPercentage, int carbohydratePercentage, int fatPercentage)
    {
        return proteinPercentage + carbohydratePercentage + fatPercentage == 100;
    }

}
