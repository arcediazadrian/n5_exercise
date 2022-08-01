using System;
using System.Collections.Generic;

namespace PermissionsAPI.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; } = null!;
        public string EmployeeLastName { get; set; } = null!;
        public int PermissionTypeId { get; set; }
        public DateTime GrantedDate { get; set; }

        public virtual PermissionType PermissionType { get; set; } = null!;
    }
}
