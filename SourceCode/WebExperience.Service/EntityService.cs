using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;
using WebExperience.Repository;

namespace WebExperience.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var newObj = _repository.Add(entity);
            _unitOfWork.Commit();
            return newObj;
        }
        public virtual void Create(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            foreach (var entity in entities)
                _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll().AsQueryable();
        }

        public IQueryable<T> GellAllQueryWithSort(string sortIndex, string sortDirection)
        {
            return _repository.GellAllQueryWithSort(sortIndex, sortDirection);
        }
        public int Count()
        {
            return _repository.Count();
        }

    }
}
