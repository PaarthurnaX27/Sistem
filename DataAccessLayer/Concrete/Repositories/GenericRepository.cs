using System;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        SmServisContext c = new SmServisContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
            
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
               c.SaveChanges();
        }

        public List<T> GetList()
        {
           
            return _object.ToList();
            
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            //c.Entry(p).DetectChanges();
            var updatedEntity = c.Entry(p);
            //updatedEntity.State = EntityState.Detached;
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
            
        }
    }
}

