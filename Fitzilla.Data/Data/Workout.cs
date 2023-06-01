using Fitzilla.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Data
{
    public class Workout : IEntity
    {
        public Guid Id { get; set; }

        ///<summary>
        /// Workout's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Workout's dscription.
        /// </summary>
        public string Description { get; set; }

        ///<summary>
        /// Workout's foreignKey
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        /// <summary>
        /// Related User instance.
        /// </summary>
        public User User { get; set; }


        /// <summary>
        /// Workout's targeted group muscle.
        /// </summary>
        public TargetMuscle TargetMuscle { get; set; }

        [InverseProperty("Workout")]
        public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
