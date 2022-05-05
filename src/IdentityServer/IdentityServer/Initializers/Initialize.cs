using IdentityServer.Persistance;

namespace IdentityServer.Initializers
{
    public partial class DbInitializer
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            try
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                RolesInitialize(context);
                UsersInitialize(serviceScope, context).Wait();
            }
            catch (Exception E)
            {
            }
        }
    }
}
