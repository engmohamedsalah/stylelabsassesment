using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.DAL;
using WebExperience.Repository;

namespace WebExperience.Service
{
    public class AssetService : EntityService<Asset>, IAssetService
    {
        IUnitOfWork _unitOfWork;
        IAssetRepository _assetRepository;

        public AssetService(IUnitOfWork unitOfWork, IAssetRepository assetRepository)
            : base(unitOfWork, assetRepository)
        {
            _unitOfWork = unitOfWork;
            _assetRepository = assetRepository;
        }


        public Asset GetById(Guid assetId)
        {
            return _assetRepository.GetById(assetId);
        }
    }
}
