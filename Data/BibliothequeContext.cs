using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bibliotheque.Models;

namespace Bibliotheque.Data
{
    public class BibliothequeContext : DbContext
    {
        public BibliothequeContext (DbContextOptions<BibliothequeContext> options)
            : base(options)
        {
        }

        public DbSet<Bibliotheque.Models.Livre> Livre { get; set; }
    }
}
