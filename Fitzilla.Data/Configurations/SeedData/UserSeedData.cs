using Fitzilla.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Fitzilla.Models.Enums;

namespace Fitzilla.DAL.Configurations.SeedData;

public static class UserSeedData
{
    public static List<User> Users()
    {
        return new List<User>()
        {
            new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Test Name",
                LastName = "Test Last Name",
                Email = "test@email.com",
                PasswordHash = "password123.",
                DateOfBirth = DateTime.Now,
                Gender = "Male",
                Weight = 80,
                Height = 180,
                Measurement = Measurement.METRIC,
            }
        }; 
    }
}
