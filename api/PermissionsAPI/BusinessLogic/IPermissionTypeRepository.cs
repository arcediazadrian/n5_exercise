using Domain;

namespace PermissionsAPI
{
    public interface IPermissionTypeRepository
    {
        Task<IEnumerable<PermissionType>> GetPermissionTypes();
        Task<PermissionType> GetPermissionTypeById(int id);
        void InsertPermissionType(PermissionType permissionType);
        Task DeletePermissionType(int id);
        Task UpdatePermissionType(int id, PermissionType permissionType);
        Task Save();
    }
}
