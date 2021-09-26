using System;
using System.Collections;
using TicketSystemRepo.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace TicketSystemRepo
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private Hashtable _repos;
        private readonly TicketSystemContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWorks(TicketSystemContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repos == null)
            {
                _repos = new Hashtable();
            }

            var type = typeof(T).Name;
            if (!_repos.ContainsKey(type))
            {
                var repoType = typeof(GenericRepository<>);

                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), _context);
                _repos.Add(type, repoInstance);
            }
            return (IGenericRepository<T>)_repos[type];
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
