using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    public interface IBaseRepository<T> where T : EntityBase
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(Guid id);
        List<T> GetAll();
    }
