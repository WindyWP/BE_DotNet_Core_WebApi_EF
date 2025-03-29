using Microsoft.EntityFrameworkCore;

namespace BE_WebApi_Core.Models
{
    public class SiswaContext : DbContext
    {
        public SiswaContext(DbContextOptions<SiswaContext> options) : base(options) 
        { 
        
        }

        public DbSet<SiswaModel> SiswaModels { get; set; }

    }
}
