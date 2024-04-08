using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Application.Models;
using MultiTenantApi.Common.Base.Interfaces;
using MultiTenantApi.Common.Models;

namespace MultiTenantApi.Common.Base.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantConfigurationService _tenantConfigurationService;
        public string CurrentTenantId { get; set; }

        public ApplicationDbContext(ITenantConfigurationService tenantConfigurationService, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _tenantConfigurationService = tenantConfigurationService;
            CurrentTenantId = _tenantConfigurationService.TenantId;
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Product> Products { get; set; }

        // On Model Creating - multitenancy query filters 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasQueryFilter(a => a.TenantId == CurrentTenantId);
        }

        // On Save Changes - write tenant Id to table
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId;
                        break;
                }
            }
            var result = base.SaveChanges();
            return result;
        }
    }
}
