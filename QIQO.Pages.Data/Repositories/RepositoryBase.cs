using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QIQO.Pages.Data.Repositories
{
    public class RepositoryBase
    {
        protected bool disposed = false;
        protected DbContext Context { get; set; }

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    Context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
