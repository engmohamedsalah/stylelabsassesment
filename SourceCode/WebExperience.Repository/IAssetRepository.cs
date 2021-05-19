using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;

namespace WebExperience.Repository
{

    /// <summary>
    /// interface for operation that can be done on the asset Repository
    /// </summary>
    /// <remarks></remarks>
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        Asset GetById(Guid assetId);
        void AddOrModify(IList<Asset> entity);
        void AddOrModify(Asset entity);
    }
}
