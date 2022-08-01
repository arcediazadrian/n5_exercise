using Microsoft.AspNetCore.Mvc;
using PermissionsAPI.Models;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {

        private PermissionUnitOfWork unitOfWork = new PermissionUnitOfWork();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissions = await unitOfWork.PermissionRepository.GetPermissions();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await unitOfWork.PermissionRepository.GetPermissionById(id);
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permission permission)
        {
            unitOfWork.PermissionRepository.InsertPermission(permission);
            await unitOfWork.PermissionRepository.Save();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Permission permissionToUpdate)
        {
            await unitOfWork.PermissionRepository.UpdatePermission(id, permissionToUpdate);
            await unitOfWork.PermissionRepository.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await unitOfWork.PermissionRepository.DeletePermission(id);
            await unitOfWork.PermissionRepository.Save();

            return Ok();
        }
    }
}