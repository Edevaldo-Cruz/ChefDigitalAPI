﻿using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ChefDigital.Infra.Repository.Generics
{
 
    //Copiar o codigo IDisposable
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public Repository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public virtual async Task<T> Add(T Objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }

            return Objeto;
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetEntityById(Guid id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task<T> Edit(T Objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
            return Objeto;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().AnyAsync(condition);
            }
        }

        public async Task<T> ExistsEntityAsync(Expression<Func<T, bool>> condition)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().FirstOrDefaultAsync(condition);
            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}

