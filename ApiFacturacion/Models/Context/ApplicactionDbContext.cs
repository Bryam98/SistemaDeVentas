using Microsoft.EntityFrameworkCore;

namespace ApiFacturacion.Models.Context
{
    public class ApplicactionDbContext : DbContext
    {
        public ApplicactionDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
