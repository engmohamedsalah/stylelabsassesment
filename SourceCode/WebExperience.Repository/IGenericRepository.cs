using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;

namespace WebExperience.Repository
{
    /// <summary>
    /// generic repository
    /// contain the most common operation that can be done 
    /// on the 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public interface IGenericRepository<T> where T : BaseEntity
    {

        IEnumerable<T> GetAll();
        IQueryable<T> GellAllQueryWithSort(string sortIndex, string sortDirection);
        int Count();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void AddBulk(List<T> entities);
        void AddBulkWithoutPackage(IEnumerable<T> entities);
        T Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> filter);
        void Edit(T entity);
        void Save();
    }
}
