using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class RestoranContext : DbContext
    {
        public DbSet<Dezert> Dezerti { get; set; }
        public DbSet<Jela> Jela { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Narudzbina> Narudzbine { get; set; }
        public DbSet<Pica> Pica { get; set; }

        public DbSet<Restoran> Restorani { get; set;}
        public RestoranContext(DbContextOptions options):base(options)
        {
            
        }
    }
}