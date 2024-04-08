using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Base.Contexts;
using MultiTenantApi.Common.Base.Interfaces;
using MultiTenantApi.Common.Models;

namespace MultiTenantApi.Common.Base.Services
{
    public class TenantConfigurationService : ITenantConfigurationService
    {
        private readonly TenantDbContext _tenantDbcontext;
        public string TenantId { get; set; }

        public TenantConfigurationService(TenantDbContext tenantDbcontext)
        {
            _tenantDbcontext = tenantDbcontext;
            TenantId = string.Empty;
        }

        public async Task<bool> SetTenant(string tenant)
        {
            Tenant? tenantInfo = await _tenantDbcontext.Tenants.Where(x => x.Id == tenant).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id;
                return true;
            }
            else
            {
                // TODO log error
                throw new Exception("Tenant invalid");
            }
        }
    }
}
