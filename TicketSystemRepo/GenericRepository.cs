using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TicketSystemRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TicketSystemContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(TicketSystemContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Entity()
        {
            return _dbSet;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null && includeProperties.Count() > 0)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = GetById(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
