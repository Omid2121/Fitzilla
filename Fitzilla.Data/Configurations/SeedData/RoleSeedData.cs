using Microsoft.AspNetCore.Identity;

namespace Fitzilla.DAL.Configurations.SeedData
{
    public static class RoleSeedData
    {
        public static List<IdentityRole> Roles()
        {
            return 
            [
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"

                },
                new IdentityRole
                {
                    Name = "Consumer",
                    NormalizedName = "CONSUMER"
                }
            ];
        }
    }
}
