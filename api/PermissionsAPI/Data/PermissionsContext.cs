using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class PermissionsContext : DbContext
    {
        public PermissionsContext()
        {
        }

        public PermissionsContext(DbContextOptions<PermissionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionType> PermissionTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-M9VEJBQU;Database=n5_exercise;user id=n5;password=test123;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.EmployeeFirstName).HasColumnType("text");

                entity.Property(e => e.EmployeeLastName).HasColumnType("text");

                entity.Property(e => e.GrantedDate).HasColumnType("date");
            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
