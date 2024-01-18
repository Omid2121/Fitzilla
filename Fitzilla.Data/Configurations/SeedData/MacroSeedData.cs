using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.Configurations.SeedData;

public static class MacroSeedData
{
    public static List<Macro> Macros()
    {
        User? user = UserSeedData.Users().FirstOrDefault();
        return new List<Macro>()
        {
            new Macro
            {
                Id = Guid.NewGuid(),
                Title = "Test Macro",
                ConsumeType = GoalType.SURPLUS,
                Intensity = ActivityLevel.SEDENTARY,
                Calorie = 3000,
                Protein = 70,
                Carbohydrate = 330,
                Fat = 45,
                CreatedAt = DateTime.Now,
                CreatorId = user.Id,
                Creator = user,
            }
        };
    }
}
