using Microsoft.EntityFrameworkCore;
using System;

namespace QIQO.Pages.Data.Repositories
{
    public class RepositoryBase
    {
        private bool disposed = false;
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
