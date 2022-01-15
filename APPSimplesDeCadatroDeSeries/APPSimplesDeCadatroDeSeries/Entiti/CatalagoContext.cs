using APPSimplesDeCadatroDeSeries.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPSimplesDeCadatroDeSeries.Entiti
{
    class CatalagoContext : DbContext
    {

        public CatalagoContext(DbContextOptions<CatalagoContext> options) : base(options)
        {

        }

        public DbSet<Series> SeriesDb { get; set; }


    }
}
