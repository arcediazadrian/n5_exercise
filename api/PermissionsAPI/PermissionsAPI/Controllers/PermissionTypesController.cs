using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private PermissionUnitOfWork unitOfWork = new PermissionUnitOfWork();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissionTypes = await unitOfWork.PermissionTypeRepository.GetPermissionTypes();

            return Ok(permissionTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permissionType = await unitOfWork.PermissionTypeRepository.GetPermissionTypeById(id);

            return Ok(permissionType);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionType permissionType)
        {
            unitOfWork.PermissionTypeRepository.InsertPermissionType(permissionType);
            await unitOfWork.Save();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionType permissionTypeToUpdate)
        {
            await unitOfWork.PermissionTypeRepository.UpdatePermissionType(id, permissionTypeToUpdate);
            await unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await unitOfWork.PermissionTypeRepository.DeletePermissionType(id);
            await unitOfWork.Save();

            return Ok();
        }
    }
}
