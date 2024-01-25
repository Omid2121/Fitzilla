namespace Fitzilla.Models.Data
{
    public class NutritionInfo : IEntity
    {
        /// <summary>
        /// The unique identifier for the Nutrition info.
        /// </summary>
        public Guid Id { get; set; }

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
        /// The relationship between the Nutrition Info and the macro.
        /// </summary>
        public Guid MacroId { get; set; }
        public virtual Macro Macro { get; set; }
    }
}
