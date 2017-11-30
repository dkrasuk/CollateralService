using BusinessLayer.Interfaces;
using Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;
using System.Data.Entity;

namespace BusinessLayer
{
    class CollateralAgreementService : Service<CollateralAgreement>, ICollateralAgreementService
    {
        private readonly IRepositoryAsync<CollateralAgreement> _repository;
        public CollateralAgreementService(IRepositoryAsync<CollateralAgreement> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralAsync(string collateralAgreementId)
        {
            var collateralAgreement = await _repository.Queryable()
                .Include(i => i.Collateral)
                .FirstOrDefaultAsync(ca => ca.Id == collateralAgreementId);
            var collateral = collateralAgreement
                .Collateral
                .Select(c => (Models.Dto.Collateral.Collateral)c);
            return collateral;
        }

        public async Task<bool> IsExists(string id)
        {
            return await _repository.Queryable().AnyAsync(x => x.Id == id);
        }
    }
}
