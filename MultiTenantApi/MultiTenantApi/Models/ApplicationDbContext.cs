using Microsoft.EntityFrameworkCore;

namespace MultiTenantApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
