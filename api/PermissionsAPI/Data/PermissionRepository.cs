using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PermissionRepository: IPermissionRepository, IDisposable
    {
        private PermissionsContext context;

        public PermissionRepository(PermissionsContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            await context.Permissions.Include(p => p.PermissionType).LoadAsync();

            return context.Permissions.OrderBy(b => b.Id).ToList();
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            var permission = await context.Permissions.Where(p => p.Id == id).Include(p => p.PermissionType).FirstOrDefaultAsync();
            return permission;
        }

        public void InsertPermission(Permission permission)
        {
            permission.GrantedDate = DateTime.Now;
            context.Permissions.Add(permission);
        }

        public async Task DeletePermission(int id)
        {
            Permission permission = await context.Permissions.Where(p => p.Id == id).FirstOrDefaultAsync();
            context.Permissions.Remove(permission);
        }

        public async Task UpdatePermission(int id, Permission permissionToUpdate)
        {
            var permission = await context.Permissions.Where(p => p.Id == id).FirstOrDefaultAsync();

            permission.EmployeeFirstName = permissionToUpdate.EmployeeFirstName;
            permission.EmployeeLastName = permissionToUpdate.EmployeeLastName;
            permission.PermissionTypeId = permissionToUpdate.PermissionTypeId;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
            return;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
