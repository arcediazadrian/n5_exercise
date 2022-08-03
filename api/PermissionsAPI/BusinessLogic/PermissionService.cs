using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class PermissionService : IPermissionService
    {
        private IPermissionUnitOfWork permissionUnitOfWork;

        public PermissionService(IPermissionUnitOfWork permissionUnitOfWork)
        {
            this.permissionUnitOfWork = permissionUnitOfWork;
        }

        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            return await permissionUnitOfWork.PermissionRepository.GetPermissions();
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await permissionUnitOfWork.PermissionRepository.GetPermissionById(id);
        }

        public async Task InsertPermission(Permission permission)
        {
            validatePermission(permission);
            await validateIfPermissionTypeExists(permission.PermissionTypeId);

            permissionUnitOfWork.PermissionRepository.InsertPermission(permission);
            await permissionUnitOfWork.Save();
        }

        public async Task DeletePermission(int id)
        {
            await validateIfPermissionExists(id);

            await permissionUnitOfWork.PermissionRepository.DeletePermission(id);
            await permissionUnitOfWork.Save();
        }

        public async Task UpdatePermission(int id, Permission permissionToUpdate)
        {
            validatePermission(permissionToUpdate);
            await validateIfPermissionExists(id);
            await validateIfPermissionTypeExists(permissionToUpdate.PermissionTypeId);

            await permissionUnitOfWork.PermissionRepository.UpdatePermission(id, permissionToUpdate);
            await permissionUnitOfWork.Save();
        }

        private void validatePermission(Permission permission)
        {
            if (permission == null || permission.EmployeeFirstName == string.Empty || permission.EmployeeLastName == string.Empty || permission.PermissionTypeId < 1)
                throw new BadRequestException();
        }

        private async Task validateIfPermissionExists(int id)
        {
            var permission = await permissionUnitOfWork.PermissionRepository.GetPermissionById(id);
            if(permission == null)
                throw new BadRequestException();
        }

        private async Task validateIfPermissionTypeExists(int id)
        {
            var permissionType = await permissionUnitOfWork.PermissionTypeRepository.GetPermissionTypeById(id);
            if (permissionType == null)
                throw new BadRequestException();
        }
    }
}
