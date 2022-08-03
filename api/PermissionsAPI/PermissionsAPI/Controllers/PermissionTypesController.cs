using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace PermissionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private IPermissionTypeService permissionTypeService;

        public PermissionTypesController(IPermissionTypeService permissionTypeService)
        {
            this.permissionTypeService = permissionTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissionTypes = await permissionTypeService.GetPermissionTypes();
            return Ok(permissionTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permissionType = await permissionTypeService.GetPermissionTypeById(id);
            return Ok(permissionType);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionType permissionType)
        {
            await permissionTypeService.InsertPermissionType(permissionType);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionType permissionTypeToUpdate)
        {
            await permissionTypeService.UpdatePermissionType(id, permissionTypeToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await permissionTypeService.DeletePermissionType(id);
            return Ok();
        }
    }
}
