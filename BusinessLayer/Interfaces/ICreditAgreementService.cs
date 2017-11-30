using Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Dto.Car;
using BusinessLayer.Models.Dto.Mortgage;

namespace BusinessLayer.Interfaces
{
    public interface ICreditAgreementService : IService<CreditAgreement>
    {
        Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralAsync(string creditAgreementId);
        Task<IEnumerable<Models.Dto.CollateralAgreement.CollateralAgreement>> GetCollateralAgreementsAsync(string creditAgreementId);
        Task<bool> IsExists(string id);
        Task<IEnumerable<Models.Dto.CollateralAgreement.CollateralAgreement>> GetCollateralAgreementByCollateralAndCreditAgreement(string id, string collateralId);
        Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralsByAgreementIdAsync(string agreementId);
    }
}
