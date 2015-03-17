namespace Supermarket.Data.Repository
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> : IDisposable where T : class
    {
        ICollection<T> GetAll();

        T Get(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}