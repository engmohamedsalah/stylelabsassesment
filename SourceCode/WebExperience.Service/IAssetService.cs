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
    /// <remarks></remarks>
    public interface IAssetService : IEntityService<Asset>
    {
        Asset GetById(Guid assetId);
    }
}
