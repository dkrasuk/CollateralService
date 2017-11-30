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
using BusinessLayer.Models.Dto.Car;
using BusinessLayer.Models.Dto.Mortgage;

namespace BusinessLayer
{
    class CreditAgreementService : Service<CreditAgreement>, ICreditAgreementService
    {
        private readonly IRepositoryAsync<CreditAgreement> _repository;
        public CreditAgreementService(IRepositoryAsync<CreditAgreement> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralAsync(string id)
        {
            var creditAgreement = await _repository.Queryable()
                .Include(i => i.OtherProperty)
                .FirstOrDefaultAsync(ca => ca.Id == id);
            var collateral = creditAgreement
                .OtherProperty
                .Select(c => (Models.Dto.Collateral.Collateral)c);
            return collateral;
        }

        public async Task<IEnumerable<Models.Dto.CollateralAgreement.CollateralAgreement>> GetCollateralAgreementsAsync(string id)
        {
            var creditAgreements = await _repository.Queryable()
                .Include(i => i.CollateralAgreements)
                .FirstOrDefaultAsync(ca => ca.Id == id);

            var collateralAgreement = creditAgreements?
                .CollateralAgreements
                .Select(x => (Models.Dto.CollateralAgreement.CollateralAgreement)x);

            return collateralAgreement;
        }

        public async Task<bool> IsExists(string id)
        {
            return await _repository.Queryable().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Models.Dto.CollateralAgreement.CollateralAgreement>> GetCollateralAgreementByCollateralAndCreditAgreement(string id, string collateralId)
        {

            var collateral = _repository.Queryable()
                .Include(i => i.CollateralAgreements)
                .Where(x => x.Id == id).SelectMany(x => x.CollateralAgreements);

            var s = collateral.Include(i => i.Collateral);


            var collateralAgreements = await collateral.Include(i => i.Collateral).Where(x => x.Collateral.Where(y => y.Id == collateralId).Count() > 0).ToListAsync();

            if (collateralAgreements.Count() > 0)
            {
                return collateralAgreements.Select(x => (Models.Dto.CollateralAgreement.CollateralAgreement)x);
            }

            return new List<Models.Dto.CollateralAgreement.CollateralAgreement>();

        }

        public async Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralsByAgreementIdAsync(string agreementId)
        {
            //получили ID залога
            var collateralAgreement = _repository.Queryable()
                .Include(x => x.CollateralAgreements)
                .Where(x => x.Id == agreementId)
                .SelectMany(x => x.CollateralAgreements);

            //Получили залоги
            var collaterals = collateralAgreement.Include(x => x.Collateral).SelectMany(x => x.Collateral).ToList();
            if (collaterals.Count() > 0)
                return collaterals.Select(c => (Models.Dto.Collateral.Collateral)c).ToList();

            return new List<Models.Dto.Collateral.Collateral>();

        }
    }
}
