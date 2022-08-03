using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private IPermissionUnitOfWork permissionUnitOfWork;

        public PermissionTypeService(IPermissionUnitOfWork permissionUnitOfWork)
        {
            this.permissionUnitOfWork = permissionUnitOfWork;
        }

        public async Task<IEnumerable<PermissionType>> GetPermissionTypes()
        {
            return await permissionUnitOfWork.PermissionTypeRepository.GetPermissionTypes();
        }

        public async Task<PermissionType> GetPermissionTypeById(int id)
        {
            return await permissionUnitOfWork.PermissionTypeRepository.GetPermissionTypeById(id);
        }

        public async Task InsertPermissionType(PermissionType permissionType)
        {
            permissionUnitOfWork.PermissionTypeRepository.InsertPermissionType(permissionType);
            await permissionUnitOfWork.Save();
        }

        public async Task DeletePermissionType(int id)
        {
            await permissionUnitOfWork.PermissionTypeRepository.DeletePermissionType(id);
            await permissionUnitOfWork.Save();
        }

        public async Task UpdatePermissionType(int id, PermissionType permissionTypeToUpdate)
        {
            await permissionUnitOfWork.PermissionTypeRepository.UpdatePermissionType(id, permissionTypeToUpdate);
            await permissionUnitOfWork.Save();
        }
    }
}
