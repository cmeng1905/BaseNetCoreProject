using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class AppDataContext : DbContext
    {
        //Add-Migration AppDataDbInitial
        //Update-Database
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);
            base.OnModelCreating(modelBuilder);

            // Seed initial data
        }
    }
}
