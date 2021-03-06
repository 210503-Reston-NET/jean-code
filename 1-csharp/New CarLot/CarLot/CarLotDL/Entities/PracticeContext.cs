using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarLotDL.Entities
{
    public partial class PracticeContext : DbContext
    {
        public PracticeContext()
        {
        }

        public PracticeContext(DbContextOptions<PracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            
            modelBuilder.Entity<Car>(entity =>
            {
            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("inventoryid");
            entity.Property(e => e.locationId).HasColumnName("locationid");


            entity.Property(e => e.Year)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("year");

            entity.Property(e => e.Make)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("make");

            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("model");
            });


            modelBuilder.Entity<Description>(entity =>
            {
            entity.ToTable("descriptions");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mpg).HasColumnName("mpg");

            entity.Property(e => e.Rating)
                .IsRequired()
                .HasMaxLength(240)
                .HasColumnName("rating");

            entity.Property(e => e.Id).HasColumnName("price");

            entity.HasOne(d => d.Car)
                .WithMany(p => p.Descriptions)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("FK__descripti__inven__37703C52");
            });

            
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("customerid");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pin");
            });

            modelBuilder.Entity<Location>(entity =>
            {
            entity.ToTable("locations");

            entity.Property(e => e.Id).HasColumnName("locationid");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("City");

            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("State");

            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Country");
            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
