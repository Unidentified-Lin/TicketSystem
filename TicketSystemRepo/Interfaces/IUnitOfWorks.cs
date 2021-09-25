using System;
namespace TicketSystemRepo.Interfaces
{
    public interface IUnitOfWorks
    {
        IGenericRepository<T> Repository<T>() where T : class;
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChange();
    }
}
