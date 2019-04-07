using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Threading.Tasks;

namespace learningspace_web_bot.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Classe para contexto de banco
        internal DbContext context;
        // Conjunto de entidades do repositório instanciado
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        // Cria um Iqueryable do objeto
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {

            // Aqui embaixo va ser metodos para tratamento da Iqueryable
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }



            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        // Metodos que podem ser usados depois do tratamento
        public virtual TEntity GetByID(params object[] id)
        {
            return dbSet.Find(id);
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
