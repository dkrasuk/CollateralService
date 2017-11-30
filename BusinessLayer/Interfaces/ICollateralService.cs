using Entities.Models;
using Newtonsoft.Json.Linq;
using Service.Pattern;
using System.Threading.Tasks;
using BusinessLayer.Models.Dto.Car;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICollateralService : IService<Collateral>
    {
        Task<Models.Dto.Car.Car> GetCarDetailsAsync(string collaterailId);
        Task<Models.Dto.Mortgage.Mortgage> GetMortgageDetailsAsync(string collaterailId);
        Task<Models.Dto.OtherCollateral.OtherCollateral> GetOtherCollateralDetailsAsync(string collaterailId);
        Task PutCollateralAsync(Models.Dto.Collateral.Collateral collateral);
        Task<string> PostCollateralToCollateralAgreementAsync(string id, Models.Dto.Collateral.Collateral dtoCollateral);
        Task<string> PostCollateralToCreditagreementAsync(string id, Models.Dto.Collateral.Collateral dtoCollateral);
        Task<Models.Dto.Collateral.Collateral> GetCollateralByCollateralIdAsync(string collaterailId);
        Task<string> PostEvaluationAsync(string id, Models.Dto.Collateral.Evaluation evaluation);
        Task<bool> DeleteCollateralAsync(string id, string userlogin);
        Task<bool> ChangeCollateralLinks(string id, string newCollateralAgreementId, string oldCollateralAgreementId);
        Task<IEnumerable<string>> GetAgreementIdByCollateralIdAsync(string collateralId);
        Task<List<Models.Dto.Collateral.Evaluation>> GetEvaluationByCollateralIdAsync(string collaterailId);
        Task<Models.Dto.Collateral.Location> GetLocationCollateralIdAsync(string id);
        Task PostLocationAsync(string id, Models.Dto.Collateral.Location location);

        Task<IEnumerable<string>> GetAllAgreementsIdAsync();

    }
}
