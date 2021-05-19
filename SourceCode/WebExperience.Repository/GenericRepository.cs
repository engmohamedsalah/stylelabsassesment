using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;
using System.Linq.Dynamic;


using EntityFramework.MappingAPI;
using EntityFramework.BulkInsert.Providers;
using EntityFramework.BulkInsert.Extensions;
using System.Threading;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Contexts;

namespace WebExperience.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {

            _entities = context;
            _dbset = context.Set<T>();

        }


        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public  void DeleteWhere(Expression<Func<T, bool>> filter)
        {
            string selectSql = _dbset.ToString();
            string fromWhere = selectSql.Substring(selectSql.IndexOf("FROM"));
            //string deleteSql = string.Format("DELETE [Extent1] " + fromWhere + " DBCC CHECKIDENT ('[{0}]', RESEED, 0)", _dbset.ElementType.Name);
            string deleteSql = string.Format("DELETE [Extent1] " + fromWhere  , _dbset.ElementType.Name);
            _entities.Database.CommandTimeout = 1000;
            _entities.Database.ExecuteSqlCommand(deleteSql);
        }

        public IQueryable<T> GellAllQueryWithSort(string sortIndex,string sortDirection)
        {
            return _dbset.OrderBy(sortIndex +" " +sortDirection).AsQueryable();

            
            //return (from tlb in _dbset orderby tlb.ToString()+"."+sortIndex + " " + sortDirection select tlb); 
        }

        public int Count()
        {
            return _dbset.Count();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
        public void AddBulk(List<T> entities)
        {
            foreach(var  entity in entities)
            {
                //entities
            }
            _entities.BulkInsert(entities);
            Save();
        }
     
        public void AddBulkWithoutPackage(IEnumerable<T> entities)
        {
            _entities.Configuration.AutoDetectChangesEnabled = false;
            int page = 1000;
            int skip = 0;
           
            int total = entities.Count();
            IEnumerable<T> chnuckEntities;


            while(skip < total)
            {
                if (skip + page > total)
                {
                    chnuckEntities = entities.Skip(skip);
                    skip = total;
                }
                else
                {
                    chnuckEntities = entities.Skip(skip).Take(page);
                    skip += page;
                }
                var ctx = new AssetContext();
                var tempDBSet = ctx.Set<T>();

                //////////////////////
                var newThread = new Task(() =>
                {
                    foreach(var e in chnuckEntities)
                    {
                        tempDBSet.Add(e);
                      
                    }
                    ctx.SaveChanges();
                    
                });
                // Start the task.
                newThread.Start();

                // Output a message from the calling thread.
                Console.WriteLine("start thread to save bulk with page size'{0}'.",page);
                //newThread.Wait();
                /////////////////////////
            }


            _entities.Configuration.AutoDetectChangesEnabled = true;
            Save();

        }
    }
}
