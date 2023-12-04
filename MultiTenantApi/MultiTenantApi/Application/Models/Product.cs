
using MultiTenantApi.Common.Base.Interfaces;

namespace MultiTenantApi.Application.Models
{
    public class Product : ITenant
    {
        public int Id { get; set; }
        public string? Name { get; set;}
        public decimal Price { get; set;}
        public string? TenantId { get; set; }
    }
}
