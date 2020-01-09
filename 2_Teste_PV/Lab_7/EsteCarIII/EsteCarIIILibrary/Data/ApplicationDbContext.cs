using EsteCarIIILibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EsteCarIIILibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext<Cliente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marca { get; set; }

        public DbSet<Carro> Carro { get; set; }

        public DbSet<Aluguer> Aluguer { get; set; }
    }
}
