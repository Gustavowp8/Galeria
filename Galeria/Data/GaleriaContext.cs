using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Galeria.Models;

namespace Galeria.Data
{
    public class GaleriaContext : DbContext
    {
        public GaleriaContext (DbContextOptions<GaleriaContext> options)
            : base(options)
        {
        }

        public DbSet<Galeria.Models.Clientes> Clientes { get; set; } = default!;

        public DbSet<Galeria.Models.GaleriaImg> GaleriaImgs { get; set; } = default!;

        public DbSet<Galeria.Models.Imagem> Imagens { get; set; } = default!;
    }
}
