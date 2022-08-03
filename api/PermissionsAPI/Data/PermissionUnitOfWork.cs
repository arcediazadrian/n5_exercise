namespace Data
{
    public class PermissionUnitOfWork
    {
        private PermissionsContext context = new PermissionsContext();
        private PermissionRepository permissionRepository;
        private PermissionTypeRepository permissionTypeRepository;

        public PermissionRepository PermissionRepository
        {
            get
            {

                if (this.permissionRepository == null)
                {
                    this.permissionRepository = new PermissionRepository(context);
                }
                return permissionRepository;
            }
        }

        public PermissionTypeRepository PermissionTypeRepository
        {
            get
            {

                if (this.permissionTypeRepository == null)
                {
                    this.permissionTypeRepository = new PermissionTypeRepository(context);
                }
                return permissionTypeRepository;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
            return;
        }
    }
}
