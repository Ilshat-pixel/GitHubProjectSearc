using IdentityServer.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Initializers
{
    public partial class DbInitializer
    {
        private static void RolesInitialize(ApplicationDbContext dbContext)
        {
            var rolesDbSet = dbContext.Roles as DbSet<IdentityRole>;
            var roles = rolesDbSet.ToList();
            if (!roles.Any(x => x.Name == "Users"))
            {
                rolesDbSet.Add(new IdentityRole { Name = "Users", NormalizedName = "Users".ToUpperInvariant() });
            }
            dbContext.SaveChanges();
        }
    }
}
