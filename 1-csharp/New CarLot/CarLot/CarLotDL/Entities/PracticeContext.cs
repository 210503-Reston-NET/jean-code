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

        public virtual DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            
            modelBuilder.Entity<Car>(entity =>
            {
            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");

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
            entity.ToTable("descriptionTable");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mpg)
                .IsRequired()
                .HasMaxLength(240)
                .HasColumnName("Mpg");

            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.Property(e => e.CarId).HasColumnName("carID");

            entity.HasOne(d => d.Car)
                .WithMany(p => p.Descriptions)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__descripti__carID__7E37BEF6");
            });

            
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FirstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LastName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
