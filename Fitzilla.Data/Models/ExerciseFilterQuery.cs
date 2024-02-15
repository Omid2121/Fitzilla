using Fitzilla.Models.Enums;

namespace Fitzilla.DAL.Models
{
    public class ExerciseFilterQuery
    {
        public ICollection<TargetMuscle> TargetMuscles { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
    }
}
