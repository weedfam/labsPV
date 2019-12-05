using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESTeCar.Models;

namespace ESTeCar.Models
{
    public class ESTeCarContext : DbContext
    {
        public ESTeCarContext (DbContextOptions<ESTeCarContext> options)
            : base(options)
        {
        }

        public DbSet<ESTeCar.Models.Carro> Carro { get; set; }

        public DbSet<ESTeCar.Models.Marca> Marca { get; set; }
    }
}
