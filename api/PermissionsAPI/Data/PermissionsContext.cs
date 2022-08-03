using Domain.Models;
using Microsoft.EntityFrameworkCore;

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
