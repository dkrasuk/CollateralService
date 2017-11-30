using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollateralService.ApiClient.Client
{

    /// <summary>
    /// Extension methods for CreditAgreement.
    /// </summary>
    public static partial class CreditAgreementExtensions
    {
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static IList<Models.Presentation.Responses.Collateral.CollateralAgreement> GetCollateralAgreementsByCreditAgreement(this ICreditAgreement operations, string id)
        {
            return operations.GetCollateralAgreementsByCreditAgreementAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IList<Models.Presentation.Responses.Collateral.CollateralAgreement>> GetCollateralAgreementsByCreditAgreementAsync(this ICreditAgreement operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCollateralAgreementsByCreditAgreementWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateralId'>
        /// </param>
        public static IList<Models.Presentation.Responses.Collateral.CollateralAgreement> GetCollateralAgreementByCreditAndCollateral(this ICreditAgreement operations, string id, string collateralId)
        {
            return operations.GetCollateralAgreementByCreditAndCollateralAsync(id, collateralId).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateralId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IList<Models.Presentation.Responses.Collateral.CollateralAgreement>> GetCollateralAgreementByCreditAndCollateralAsync(this ICreditAgreement operations, string id, string collateralId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCollateralAgreementByCreditAndCollateralWithHttpMessagesAsync(id, collateralId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static IList<Models.Presentation.Responses.Collateral.Collateral> GetCollateralByCreditAgreement(this ICreditAgreement operations, string id)
        {
            return operations.GetCollateralByCreditAgreementAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IList<Models.Presentation.Responses.Collateral.Collateral>> GetCollateralByCreditAgreementAsync(this ICreditAgreement operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCollateralByCreditAgreementWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static bool? IsExists(this ICreditAgreement operations, string id)
        {
            return operations.IsExistsAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<bool?> IsExistsAsync(this ICreditAgreement operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.IsExistsWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static IList<Models.Presentation.Responses.Collateral.Collateral> GetCollateralsByAgreementId(this ICreditAgreement operations, string id)
        {
            return operations.GetCollateralsByAgreementIdAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IList<Models.Presentation.Responses.Collateral.Collateral>> GetCollateralsByAgreementIdAsync(this ICreditAgreement operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCollateralsByAgreementIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
