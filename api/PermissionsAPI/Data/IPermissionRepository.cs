using Domain;

namespace Data
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Permission> GetPermissionById(int id);
        void InsertPermission(Permission permission);
        Task DeletePermission(int id);
        Task UpdatePermission(int id, Permission permission);
        Task Save();
    }
}
