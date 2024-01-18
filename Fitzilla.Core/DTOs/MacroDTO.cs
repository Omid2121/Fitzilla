using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fitzilla.BLL.DTOs;

public class CreateMacroDTO
{
    [Required]
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public double GoalWeight { get; set; }

    public DateTimeOffset CycleStartDate { get; set; }

    public DateTimeOffset CycleEndDate { get; set; }

    [Required]
    public GoalType GoalType { get; set; }

    [Required]
    public ActivityLevel ActivityLevel { get; set; }

    [Required]
    public double ProteinPercentage { get; set; }

    [Required]
    public double CarbohydratePercentage { get; set; }

    [Required]
    public double FatPercentage { get; set; }

    [Required]
    public string CreatorId { get; set; }
}
public class MacroDTO : CreateMacroDTO
{
    public Guid Id { get; set; }

    public string CreatorEmail { get; set; }
}

public class UpdateMacroDTO : CreateMacroDTO
{
}