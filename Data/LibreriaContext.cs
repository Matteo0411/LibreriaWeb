using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibreriaWeb.Models;

namespace LibreriaWeb.Data
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext (DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public DbSet<LibreriaWeb.Models.Autore> Autore { get; set; } = default!;
        public DbSet<LibreriaWeb.Models.Libro> Libro { get; set; } = default!;
    }
}
