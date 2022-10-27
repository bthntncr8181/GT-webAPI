using GTBack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GTBack.Repository
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
   
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Attributes> Attributes { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
            base.OnModelCreating(modelBuilder);
    

        }
    }
}
