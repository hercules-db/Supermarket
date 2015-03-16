namespace Supermarket.Data.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.DbSet = context.Set<T>();
            this.context = context;
        }

        protected IDbSet<T> DbSet { get; set; }

        public ICollection<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public T Get(object id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            this.Delete(Get(id));
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}