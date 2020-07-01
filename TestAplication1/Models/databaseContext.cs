
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAplication1.Models
{
    
    public class DatabaseContext : DbContext
    {
        public DbSet<Klient> klienci { get; set; }

        string connectionString= "Host=localhost; User Id=postgres; password=root; Database=test";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                connectionString
                );
        }


    }

}