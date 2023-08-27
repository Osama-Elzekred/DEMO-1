using DEMO_1.Data.config;
using DEMO_1.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO_1.Data
{
    public class ITIContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var itiCon= config.GetConnectionString("ITIConnection");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(itiCon);
        }
    }
}
