using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Core.Models;

namespace WebStore.DAL.Data.EF;
public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<StoreContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch
                {
                    throw;
                }
            }
            using (var appContext = scope.ServiceProvider.GetRequiredService<StoreIdentityContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch
                {
                    throw;
                }
            }
        }
        return webApp;
    }
}
