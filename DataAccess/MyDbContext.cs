using CarBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Client> Clients { get; set; }

        public DbSet<Garagee> Garages { get; set; }
        public MyDbContext()
        {
            Cars = this.Set<Car>();
            Clients = this.Set<Client>();
            Garages = this.Set<Garagee>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarsDb;User Id=gospodinovp;Password=1234;");
        }
    }
}
