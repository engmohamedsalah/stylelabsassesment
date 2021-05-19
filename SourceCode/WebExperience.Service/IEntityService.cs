using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;

namespace WebExperience.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        T Create(T entity);
        void Create(List<T> entity);

        void Delete(T entity);
        IEnumerable<T> GetAll();
        IQueryable<T> GellAllQueryWithSort(string sortIndex, string sortDirection);
        void Update(T entity);
        int Count();
    }
}
