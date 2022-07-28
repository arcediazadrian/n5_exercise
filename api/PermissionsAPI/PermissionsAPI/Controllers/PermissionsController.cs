using Microsoft.AspNetCore.Mvc;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Permission> Get()
        {
            using var db = new PermissionsContext();

            var permissions = db.Permissions.OrderBy(b => b.Id).ToList();

            return permissions;
        }

        [HttpGet("{id}")]
        public Permission Get(int id)
        {
            using var db = new PermissionsContext();

            var permission = db.Permissions.Where(p => p.Id == id).First();

            return permission;
        }

        [HttpPost]
        public void Post([FromBody] Permission permission)
        {
            using var db = new PermissionsContext();

            permission.GrantedDate = DateTime.Now;
            db.Add(permission);
            db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Permission permissionToUpdate)
        {
            using var db = new PermissionsContext();

            var permission = db.Permissions.Where(p => p.Id == id).First();

            permission.EmployeeFirstName = permissionToUpdate.EmployeeFirstName;
            permission.EmployeeLastName = permissionToUpdate.EmployeeLastName;
            permission.PermissionType = permissionToUpdate.PermissionType;
            db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using var db = new PermissionsContext();

            var permission = db.Permissions.Where(p => p.Id == id).First();

            db.Remove(permission);
            db.SaveChanges();
        }
    }
}