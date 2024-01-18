using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data;

public class Plan : EntityDetail
{
    public int SessionsPerWeek { get; set; }

    public int DurationInWeeks { get; set; }
    
    public string CreatorId { get; set; }
    public User Creator { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }
}
