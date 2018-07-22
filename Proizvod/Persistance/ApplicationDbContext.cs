using Proizvod.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proizvod.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
                    : base("DefaultConnection")
        {
        }

        public DbSet<ProizvodModel> Proizvodi { get; set; }

    }
}