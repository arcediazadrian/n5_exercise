using Domain.Exceptions;
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
            validateIfPermissionTypeIsValid(permissionType);

            permissionUnitOfWork.PermissionTypeRepository.InsertPermissionType(permissionType);
            await permissionUnitOfWork.Save();
        }

        public async Task DeletePermissionType(int id)
        {
            await validateIfPermissionTypeExists(id);
            await validateIfPermissionTypeIsInUse(id);

            await permissionUnitOfWork.PermissionTypeRepository.DeletePermissionType(id);
            await permissionUnitOfWork.Save();
        }

        public async Task UpdatePermissionType(int id, PermissionType permissionTypeToUpdate)
        {
            validateIfPermissionTypeIsValid(permissionTypeToUpdate);
            await validateIfPermissionTypeExists(id);

            await permissionUnitOfWork.PermissionTypeRepository.UpdatePermissionType(id, permissionTypeToUpdate);
            await permissionUnitOfWork.Save();
        }

        private void validateIfPermissionTypeIsValid(PermissionType permissionType)
        {
            if (permissionType == null || permissionType.Description == String.Empty)
                throw new BadRequestException();
        }

        private async Task validateIfPermissionTypeExists(int id)
        {
            var permissionType = await permissionUnitOfWork.PermissionTypeRepository.GetPermissionTypeById(id);
            if (permissionType == null)
                throw new BadRequestException();
        }

        private async Task validateIfPermissionTypeIsInUse(int id)
        {
            var permissions = await permissionUnitOfWork.PermissionRepository.GetPermissions();
            var permissionsUsingPermissionType = permissions.Where(p => p.PermissionTypeId == id);
            if (permissionsUsingPermissionType != null && permissionsUsingPermissionType.Count() > 0)
                throw new BadRequestException();
        }

        
    }
}
