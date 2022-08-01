using System;
using System.Collections.Generic;

namespace PermissionsAPI.Models
{
    public partial class PermissionType
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

    }
}
