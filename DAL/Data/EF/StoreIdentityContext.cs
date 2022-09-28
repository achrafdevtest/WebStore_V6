using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Core.Models;

namespace WebStore.DAL.Data.EF;

public class StoreIdentityContext : IdentityDbContext<AppUser>
{
    public StoreIdentityContext(DbContextOptions<StoreIdentityContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
