using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;

namespace WebExperience.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(DbContext context)
            : base(context)
        {

        }
        //public void AddBulk(IList<Asset> entities)
        //{

        //    _entities.Set<Asset>().AddRange(entities.Take(100));


        //    _entities.SaveChanges();
        //}
        public override IEnumerable<Asset> GetAll()
        {
            return _entities.Set<Asset>().AsEnumerable();
        }
        public void AddOrModify(Asset entity)
        {
            AddOrModify(new List<Asset>() { entity });
        }
        public void AddOrModify(IList<Asset> entities)
        {
            foreach (var entity in entities)
            {
                var exist = _entities.Set<Asset>().SingleOrDefault(e => e.Id == entity.Id);
                if (exist != null)
                {
                    Delete(exist);
                    //_entities.Entry(entity).State = EntityState.Modified;
                    Add(entity);
                }
                else
                {
                    //_entities.Entry(entity).State = EntityState.Added;
                    Add(entity);
                }
            }
        }

        public Asset GetById(Guid assetId)
        {
            return _dbset.Where(x => x.Id == assetId).FirstOrDefault();
        }
    }
}
