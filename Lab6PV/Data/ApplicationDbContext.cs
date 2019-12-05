using System;
using System.Collections.Generic;
using System.Text;
using EstCarII.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstCarII.Data
{
    public class ApplicationDbContext : IdentityDbContext<Cliente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EstCarII.Models.Marca> Marca { get; set; }

        public DbSet<EstCarII.Models.Carro> Carro { get; set; }

        public DbSet<EstCarII.Models.Aluguer> Aluguer { get; set; }
    }
}
