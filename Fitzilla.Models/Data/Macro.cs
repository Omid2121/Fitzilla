using Fitzilla.Models.Enums;

namespace Fitzilla.Models.Data;

public class Macro : EntityDetail
{
    /// <summary>
    /// The goal weight of the user for the macro cycle.
    /// </summary>
    public double GoalWeight { get; set; }

    /// <summary>
    /// The start date of the macro cycle.
    /// </summary>
    public DateTimeOffset CycleStartDate { get; set; }

    /// <summary>
    /// The end date of the macro cycle.
    /// </summary>
    public DateTimeOffset CycleEndDate { get; set; }

    /// <summary>
    /// The goal type of the user for the macro cycle.
    /// </summary>
    public GoalType GoalType { get; set; }

    /// <summary>
    /// The activity level of the user for the macro cycle.
    /// </summary>
    public ActivityLevel ActivityLevel { get; set; }

    /// <summary>
    /// The calorie amount of the macro cycle.
    /// </summary>
    public double Calorie { get; set; }

    /// <summary>
    /// The protein amount in grams.
    /// </summary>
    public double ProteinAmount { get; set; }

    /// <summary>
    /// The protein percentage.
    /// </summary>
    public int ProteinPercentage { get; set; }

    /// <summary>
    /// The carbohydrate amount in grams.
    /// </summary>
    public double CarbohydrateAmount { get; set; }

    /// <summary>
    /// The carbohydrate percentage.
    /// </summary>
    public int CarbohydratePercentage { get; set; }

    /// <summary>
    /// The fat amount in grams.
    /// </summary>
    public double FatAmount { get; set; }

    /// <summary>
    /// The fat percentage.
    /// </summary>
    public int FatPercentage { get; set; }

    /// <summary>
    /// The relationship between the macro and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }
}
