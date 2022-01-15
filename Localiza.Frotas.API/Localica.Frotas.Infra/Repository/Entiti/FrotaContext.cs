using Localica.Frotas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Infra.Repository.Entiti
{
    public class FrotaContext : DbContext
    {

        public FrotaContext(DbContextOptions<FrotaContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }

    }
}
