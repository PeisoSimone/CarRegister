using CarRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRegister.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
