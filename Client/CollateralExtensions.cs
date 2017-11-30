// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace CollateralService.ApiClient.Client
{
    using CollateralService.ApiClient;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for Collateral.
    /// </summary>
    public static partial class CollateralExtensions
    {
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static Models.Presentation.Responses.Collateral.Collateral GetCollateralByCollateralId(this ICollateral operations, string id)
        {
            return operations.GetCollateralByCollateralIdAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Models.Presentation.Responses.Collateral.Collateral> GetCollateralByCollateralIdAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCollateralByCollateralIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static IList<Models.Presentation.Responses.Collateral.Evaluation> GetEvaluationByCollateralId(this ICollateral operations, string id)
        {
            return operations.GetEvaluationByCollateralIdAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IList<Models.Presentation.Responses.Collateral.Evaluation>> GetEvaluationByCollateralIdAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetEvaluationByCollateralIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="operations"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<string> GetAgreementIdByCollateralId(this ICollateral operations, string id)
        {
            return operations.GetAgreementIdByCollateralIdAsync(id).GetAwaiter().GetResult();
        }

        /// <summary>
        /// The operations group for this extension method.
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IList<string>> GetAgreementIdByCollateralIdAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetAgreementIdByCollateralIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='evaluation'>
        /// </param>
        public static string PostEvaluation(this ICollateral operations, string id, Models.Presentation.Requests.Collateral.Evaluation evaluation)
        {
            return operations.PostEvaluationAsync(id, evaluation).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='evaluation'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostEvaluationAsync(this ICollateral operations, string id, Models.Presentation.Requests.Collateral.Evaluation evaluation, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostEvaluationWithHttpMessagesAsync(id, evaluation, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='userlogin'>
        /// </param>
        public static bool? DeleteCollateral(this ICollateral operations, string id, string userlogin)
        {
            return operations.DeleteCollateralAsync(id, userlogin).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='userlogin'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<bool?> DeleteCollateralAsync(this ICollateral operations, string id, string userlogin, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.DeleteCollateralWithHttpMessagesAsync(id, userlogin, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='newCollateralAgreementId'>
        /// </param>
        /// <param name='oldCollateralAgreementId'>
        /// </param>
        public static bool? PutCollateralLinks(this ICollateral operations, string id, string newCollateralAgreementId, string oldCollateralAgreementId)
        {
            return operations.PutCollateralLinksAsync(id, newCollateralAgreementId, oldCollateralAgreementId).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='newCollateralAgreementId'>
        /// </param>
        /// <param name='oldCollateralAgreementId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<bool?> PutCollateralLinksAsync(this ICollateral operations, string id, string newCollateralAgreementId, string oldCollateralAgreementId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PutCollateralLinksWithHttpMessagesAsync(id, newCollateralAgreementId, oldCollateralAgreementId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static Models.Presentation.Responses.Car.Car GetCarDetails(this ICollateral operations, string id)
        {
            return operations.GetCarDetailsAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Models.Presentation.Responses.Car.Car> GetCarDetailsAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetCarDetailsWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostCarToCollateralAgreement(this ICollateral operations, string id, Models.Presentation.Requests.Car.Car collateral)
        {
            return operations.PostCarToCollateralAgreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostCarToCollateralAgreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.Car.Car collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostCarToCollateralAgreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostCarToCreditAgreement(this ICollateral operations, string id, Models.Presentation.Requests.Car.Car collateral)
        {
            return operations.PostCarToCreditAgreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostCarToCreditAgreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.Car.Car collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostCarToCreditAgreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static object PutCar(this ICollateral operations, Models.Presentation.Requests.Car.Car collateral)
        {
            return operations.PutCarAsync(collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<object> PutCarAsync(this ICollateral operations, Models.Presentation.Requests.Car.Car collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PutCarWithHttpMessagesAsync(collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static Models.Presentation.Responses.Mortgage.Mortgage GetMortgageDetails(this ICollateral operations, string id)
        {
            return operations.GetMortgageDetailsAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Models.Presentation.Responses.Mortgage.Mortgage> GetMortgageDetailsAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetMortgageDetailsWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostMortgageToCollateralAgreement(this ICollateral operations, string id, Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            return operations.PostMortgageToCollateralAgreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostMortgageToCollateralAgreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.Mortgage.Mortgage collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostMortgageToCollateralAgreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostMortgageToCreditagreement(this ICollateral operations, string id, Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            return operations.PostMortgageToCreditagreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostMortgageToCreditagreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.Mortgage.Mortgage collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostMortgageToCreditagreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static object PutMortgage(this ICollateral operations, Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            return operations.PutMortgageAsync(collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<object> PutMortgageAsync(this ICollateral operations, Models.Presentation.Requests.Mortgage.Mortgage collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PutMortgageWithHttpMessagesAsync(collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static Models.Presentation.Responses.OtherCollateral.OtherCollateral GeOtherCollateralDetails(this ICollateral operations, string id)
        {
            return operations.GeOtherCollateralDetailsAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Models.Presentation.Responses.OtherCollateral.OtherCollateral> GeOtherCollateralDetailsAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GeOtherCollateralDetailsWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostOtherCollateralToCollateralAgreement(this ICollateral operations, string id, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            return operations.PostOtherCollateralToCollateralAgreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostOtherCollateralToCollateralAgreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostOtherCollateralToCollateralAgreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static string PostOtherCollateralToCreditagreement(this ICollateral operations, string id, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            return operations.PostOtherCollateralToCreditagreementAsync(id, collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostOtherCollateralToCreditagreementAsync(this ICollateral operations, string id, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostOtherCollateralToCreditagreementWithHttpMessagesAsync(id, collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        public static object PutOtherCollateral(this ICollateral operations, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            return operations.PutOtherCollateralAsync(collateral).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='collateral'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<object> PutOtherCollateralAsync(this ICollateral operations, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PutOtherCollateralWithHttpMessagesAsync(collateral, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        public static Models.Presentation.Responses.Collateral.Location GetLocationByCollateralId(this ICollateral operations, string id)
        {
            return operations.GetLocationByCollateralIdAsync(id).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Models.Presentation.Responses.Collateral.Location> GetLocationByCollateralIdAsync(this ICollateral operations, string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetLocationlIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='location'>
        /// </param>
        public static string PostLocation(this ICollateral operations, string id, Models.Presentation.Requests.Collateral.Location location)
        {
            return operations.PostLocationAsync(id, location).GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='id'>
        /// </param>
        /// <param name='location'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> PostLocationAsync(this ICollateral operations, string id, Models.Presentation.Requests.Collateral.Location location, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostLocationWithHttpMessagesAsync(id, location, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="operations"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static IList<string> GetAllAgreementId(this ICollateral operations)
        {
            return operations.GetAllAgreementIdAsync().GetAwaiter().GetResult();
        }
        /// <summary>
        /// The operations group for this extension method.
        /// </summary>
        /// <param name="operations"></param>
        /// <param name=""></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IList<string>> GetAllAgreementIdAsync(this ICollateral operations, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetAllAgreementIdWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }



    }
}
