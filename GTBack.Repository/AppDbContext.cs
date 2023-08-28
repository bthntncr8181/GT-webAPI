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
   
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(m => m.AdminUser)
                .WithMany(t => t.AdminEvent)
                .HasForeignKey(m => m.AdminUserId);


            modelBuilder.Entity<Event>()
                .HasOne(m => m.ClientUser)
                .WithMany(t => t.ClientEvent)
                .HasForeignKey(m => m.ClientUserId);

        }
    }
}
