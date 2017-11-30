using Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICollateralAgreementService : IService<CollateralAgreement>
    {
        Task<IEnumerable<Models.Dto.Collateral.Collateral>> GetCollateralAsync(string id);
        Task<bool> IsExists(string id);
    }
}
