using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Models;

namespace MultiTenantApi.Common.Base.Contexts
{
    public class TenantDbContext : DbContext
    {
        // This context is for looking up the tenant when a request comes in.
        public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
