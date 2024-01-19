using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data;

public class ExerciseTemplate : EntityDetail
{   
    public string? CreatorId { get; set; }
    public User? Creator { get; set; }

    public virtual ICollection<Media>? Medias { get; set; }
}
