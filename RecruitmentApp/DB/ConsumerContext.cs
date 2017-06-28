using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Entities;

namespace RecruitmentApp.DB
{
   public class ConsumerContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Consumer> Consumer { get; set; }

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
                .HasForeignKey<Address>(ad => ad.ConsumerId);
        }
    }
}