using Fitzilla.Models.Enums;

namespace Fitzilla.Models.Data;

public class Macro : EntityDetail
{    
    public double GoalWeight { get; set; }

    public DateTimeOffset CycleStartDate { get; set; }
    
    public DateTimeOffset CycleEndDate { get; set; }

    public GoalType GoalType { get; set; }
    
    public ActivityLevel ActivityLevel { get; set; }
    
    public double Calorie { get; set; }

    public double ProteinAmount { get; set; }
    public int ProteinPercentage { get; set; }
    
    public double CarbohydrateAmount { get; set; }
    public int CarbohydratePercentage { get; set; }
    
    public double FatAmount { get; set; }
    public int FatPercentage { get; set; }
    
    public string CreatorId { get; set; }
    public User Creator { get; set; }
}
