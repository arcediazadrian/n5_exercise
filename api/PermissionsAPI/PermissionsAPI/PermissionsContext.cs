namespace PermissionsAPI
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class PermissionsContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        public string DbPath { get; }

        public PermissionsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"data source=LAPTOP-M9VEJBQU;initial catalog=n5_exercise;User Id=n5;Password=test123;Encrypt=False");
    }

    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionType { get; set; }
        public DateTime GrantedDate { get; set; }
    }

    public class PermissionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
