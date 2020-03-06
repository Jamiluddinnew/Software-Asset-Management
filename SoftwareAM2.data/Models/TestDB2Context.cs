using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoftwareAM2.data.Models
{
    public partial class TestDB2Context : DbContext
    {
        public TestDB2Context()
        {
        }

        public TestDB2Context(DbContextOptions<TestDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDB2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<License>(entity =>
            {
                entity.Property(e => e.LicenseId).ValueGeneratedNever();

                entity.Property(e => e.LisenseEnd).HasColumnType("date");

                entity.Property(e => e.LisenseStart).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.License)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__License__UserId__25869641");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasIndex(e => e.LicenseIdd)
                    .HasName("UQ__Organiza__55AFA8674A80DC5C")
                    .IsUnique();

                entity.HasOne(d => d.LicenseIddNavigation)
                    .WithOne(p => p.Organization)
                    .HasForeignKey<Organization>(d => d.LicenseIdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Organizat__Licen__29572725");
            });
        }
    }
}
