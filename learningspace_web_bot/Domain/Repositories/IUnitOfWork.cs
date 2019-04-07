using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learningspace_web_bot.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void Save();
        void Dispose();
    }
}
