using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Base.Contexts;
using MultiTenantApi.Common.Base.Interfaces;
using MultiTenantApi.Common.Models;

namespace MultiTenantApi.Common.Base.Services
{
    public class TenantConfigurationService : ITenantConfigurationService
    {
        private readonly TenantDbContext _context;
        public string TenantId { get; set; }

        public TenantConfigurationService(TenantDbContext context)
        {
            _context = context;

        }

        public async Task<bool> SetTenant(string tenant)
        {
            Tenant? tenantInfo = await _context.Tenants.Where(x => x.Id == tenant).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                TenantId = tenant;
                return true;
            }
            else
            {
                throw new Exception("Tenant invalid");
            }
        }
    }
}
