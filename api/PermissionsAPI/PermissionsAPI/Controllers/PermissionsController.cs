using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {

        private IPermissionService permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissions = await permissionService.GetPermissions();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await permissionService.GetPermissionById(id);
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permission permission)
        {
            await permissionService.InsertPermission(permission);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Permission permissionToUpdate)
        {
            await permissionService.UpdatePermission(id, permissionToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await permissionService.DeletePermission(id);
            return Ok();
        }
    }
}