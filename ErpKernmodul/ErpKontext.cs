using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpKernmodul
{
    public class ErpKontext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // conntext ist connectionstring, der
            // //die Verbindung zur Datenbank beschreibt
            string conntext = "Server=(localdb)\\MSSQLLocalDB;Database=ErpDatenbank; Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(conntext);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
