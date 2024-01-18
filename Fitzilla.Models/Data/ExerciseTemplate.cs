using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data;

public class ExerciseTemplate : EntityDetail
{   
    public Guid MediaId { get; set; }
    public Media Media { get; set; }

    public string? CreatorId { get; set; }
    public User? Creator { get; set; }
}
