using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB
{
   public sealed class ConsumerContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Consumer> Consumer { get; set; }

        public ConsumerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Address>()
                .Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Consumer>()
                .HasKey(con => con.Id);

            modelBuilder.Entity<Consumer>()
                .HasOne(e => e.Address)
                .WithOne(ad => ad.Consumer)
                .HasForeignKey<Address>(ad => ad.ConcumerId);
        }
    }
}