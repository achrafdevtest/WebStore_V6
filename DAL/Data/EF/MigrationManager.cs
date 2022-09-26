using Microsoft.EntityFrameworkCore;

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
        }
        return webApp;
    }
}
