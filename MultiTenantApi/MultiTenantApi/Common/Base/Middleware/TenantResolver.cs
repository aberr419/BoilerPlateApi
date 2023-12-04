using MultiTenantApi.Common.Base.Interfaces;

namespace MultiTenantApi.Common.Base.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;

        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        // Get Tenant Id from incoming requests 
        // TODO: Read from cookie/JWT token once authentication is implemented
        public async Task InvokeAsync(HttpContext context, ITenantConfigurationService tenantConfigurationService)
        {
            context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
            if (!string.IsNullOrEmpty(tenantFromHeader))
            {
                await tenantConfigurationService.SetTenant(tenantFromHeader);
            }

            await _next(context);
        }
    }
}
