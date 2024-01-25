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

    public Guid NutritionInfoId { get; set; }
    public virtual NutritionInfo NutritionInfo { get; set; }

    /// <summary>
    /// The relationship between the macro and the creator.
    /// </summary>
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }
}
