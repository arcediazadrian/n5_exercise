using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class PermissionService: IPermissionService
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
            permissionUnitOfWork.PermissionRepository.InsertPermission(permission);
            await permissionUnitOfWork.Save();
        }

        public async Task DeletePermission(int id)
        {
            await permissionUnitOfWork.PermissionRepository.DeletePermission(id);
            await permissionUnitOfWork.Save();
        }

        public async Task UpdatePermission(int id, Permission permissionToUpdate)
        {
            await permissionUnitOfWork.PermissionRepository.UpdatePermission(id, permissionToUpdate);
            await permissionUnitOfWork.Save();
        }
    }
}
