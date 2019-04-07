using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace learningspace_web_bot.Domain.Repositories
{
    public class UnitOfWork<C> : IDisposable, IUnitOfWork where C : DbContext, new()
    {
        private C context = new C();
        private Hashtable repositories = new Hashtable();

        // Verifica se repositorio existe (se não cria uma instância do repositório)
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.Contains(typeof(T)))
            {
                repositories.Add(typeof(T), new Repository<T>(context));
            }
            return (IRepository<T>)repositories[typeof(T)];
        }

        public void Save()
        {
            context.SaveChanges();
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