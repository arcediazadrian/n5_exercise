using Domain.Interfaces;

namespace Data
{
    public class PermissionUnitOfWork : IPermissionUnitOfWork, IDisposable
    {
        public IPermissionRepository PermissionRepository { get; set; }
        public IPermissionTypeRepository PermissionTypeRepository { get; set; }

        private PermissionsContext context;

        public PermissionUnitOfWork(PermissionsContext context)
        {
            this.context = context;
            this.PermissionRepository = new PermissionRepository(context);
            this.PermissionTypeRepository = new PermissionTypeRepository(context);
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
