using CashTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CashTrack.Infrastructure.Data
{
    // DbContext is the main entry point for EF Core
    public class CashTrackDbContext : DbContext
    {
        // Constructor used by dependency injection
        public CashTrackDbContext(DbContextOptions<CashTrackDbContext> options)
            : base(options)
        {
        }

        // Represents the Categories table
        public DbSet<Category> Categories { get; set; }

        // Represents the Transactions table
        public DbSet<Transaction> Transactions { get; set; }

        // Represents the Users table
        public DbSet<User> Users { get; set; }

        // Configure model relationships and rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // Transaction configuration
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Amount)
                      .IsRequired();

                entity.Property(t => t.Date)
                      .IsRequired();

                // Relationship: Transaction -> Category (many-to-one)
                entity.HasOne(t => t.Category)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(t => t.CategoryId);

                // Relationship: Transaction -> User (many-to-one)
                entity.HasOne(t => t.User)
                      .WithMany(u => u.Transactions)
                      .HasForeignKey(t => t.UserId);
            });

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(255);
            });
        }
    }
}