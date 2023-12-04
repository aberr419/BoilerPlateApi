namespace MultiTenantApi.Common.Base.Interfaces
{
    public interface ITenantConfigurationService
    {
        string TenantId { get; set; }
        public Task<bool> SetTenant(string tenant);
    }
}
