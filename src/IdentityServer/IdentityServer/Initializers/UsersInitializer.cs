using IdentityServer.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IdentityServer.Initializers
{
    public partial class DbInitializer
    {
        public static async Task UsersInitialize(IServiceScope serviceScope, ApplicationDbContext dbContext)
        {
            try
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var usersDbSet = dbContext.Users as DbSet<IdentityUser>;
                var rolesDbSet = dbContext.Roles as DbSet<IdentityRole>;
                var user = usersDbSet.FirstOrDefault(x => x.UserName == "TestUser");
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = "TestUser",
                        Email = "TestUser@gmail.ru",
                        EmailConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user, "Qwerty");
                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Users").Wait();
                    }
                }
            }
            catch (Exception e)
            {

            }

        }
    }
}
