using Fitzilla.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitzilla.Models.Data
{
    public class Macro : EntityDetail
    {
        public decimal CurrentWeight { get; set; }
        
        public decimal GoalWeight { get; set; }

        public DateTimeOffset CycleStartDate { get; set; }
        
        public DateTimeOffset CycleEndDate { get; set; }

        public ConsumeType ConsumeType { get; set; }
        
        public Intensity Intensity { get; set; }
        
        public double Calorie { get; set; }
        
        public double Protein { get; set; }
        
        public double Carbohydrate { get; set; }
        
        public double Fat { get; set; }
        
        public string CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
