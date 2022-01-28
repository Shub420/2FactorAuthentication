using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2factor.Models;

namespace WebApplication2factor.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext context )
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        //public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, string includeProperties = null)
        //{
        //    IQueryable<T> query = dbset;
        //    if (filter != null)
        //        query = query.Where(filter);
        //        if (includeProperties != null)
        //        {
        //            foreach (var includeprp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                query = query.Include(includeprp);
        //            }
        //        }

        //    return query.FirstOrDefault();
        //}

        public T Get(int Id)
        {
            return dbset.Find(Id);
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null,  string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeprp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprp);
                }
            }
            //if (orderby != null)
            //{
            //    return orderby(query).ToList();
            //}
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void Remove(int id)
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}