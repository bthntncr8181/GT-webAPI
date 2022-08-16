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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cafe> Cafes { get; set; }

        public DbSet<CustomerFavoriteCafeRelation> CustomerFavoriteCafeRelation { get; set; }




        


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerFavoriteCafeRelation>().HasOne(a => a.Customer).WithMany(a => a.CustomerFavoriteCafeRelations).HasForeignKey(a=>a.CustomerId);
            modelBuilder.Entity<CustomerFavoriteCafeRelation>().HasOne(a => a.Cafe).WithMany(a => a.CustomerFavoriteCafeRelations).HasForeignKey(a => a.CafeId);

        }
    }
}
