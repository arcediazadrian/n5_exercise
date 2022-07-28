using Microsoft.AspNetCore.Mvc;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PermissionType> Get()
        {
            using var db = new PermissionsContext();

            var permissionTypes = db.PermissionTypes
                .OrderBy(b => b.Id).ToList();

            return permissionTypes;
        }

        [HttpGet("{id}")]
        public PermissionType Get(int id)
        {
            using var db = new PermissionsContext();

            var permissionType = db.PermissionTypes.Where(p => p.Id == id).First();

            return permissionType;
        }

        [HttpPost]
        public void Post([FromBody] PermissionType permissionType)
        {
            using var db = new PermissionsContext();

            db.Add(permissionType);
            db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PermissionType permissionTypeToUpdate)
        {
            using var db = new PermissionsContext();

            var permissionType = db.PermissionTypes.Where(p => p.Id == id).First();

            permissionType.Description = permissionTypeToUpdate.Description;
            db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using var db = new PermissionsContext();

            var permissionType = db.PermissionTypes.Where(p => p.Id == id).First();

            db.Remove(permissionType);
            db.SaveChanges();
        }
    }
}
