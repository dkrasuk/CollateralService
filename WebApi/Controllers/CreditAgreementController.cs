using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer.Interfaces;
using Repository.Pattern.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using WebApi.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// Credit Agreement Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("creditagreement")]
    [CustomExceptionFilter]
    public class CreditAgreementController : ApiController
    {
        private readonly ICreditAgreementService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditAgreementController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="unitOfWorkAsync">The unit of work asynchronous.</param>
        public CreditAgreementController(ICreditAgreementService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        /// <summary>
        /// Gets the collateral agreements by credit agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/collateralagreements")]
        [ResponseType(typeof(IEnumerable<BusinessLayer.Models.Presentation.Responses.CollateralAgreement.CollateralAgreement>))]
        public async Task<HttpResponseMessage> GetCollateralAgreementsByCreditAgreement(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));


            var collateralAgreements = await _service.GetCollateralAgreementsAsync(id);
            if (collateralAgreements == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, collateralAgreements.Select(c => (BusinessLayer.Models.Presentation.Responses.CollateralAgreement.CollateralAgreement)c));
        }

        /// <summary>
        /// Gets the collateral agreement by credit and collateral.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateralId">The collateral identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/{collateralId}/collateralagreements")]
        [ResponseType(typeof(IEnumerable<BusinessLayer.Models.Presentation.Responses.CollateralAgreement.CollateralAgreement>))]
        public async Task<HttpResponseMessage> GetCollateralAgreementByCreditAndCollateral(string id, string collateralId)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(collateralId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);


            var collateralAgreements = await _service.GetCollateralAgreementByCollateralAndCreditAgreement(id, collateralId);
            if (collateralAgreements ==  null)
            {
                return  Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, collateralAgreements.Select(x => (BusinessLayer.Models.Presentation.Responses.CollateralAgreement.CollateralAgreement)x));

        }

        /// <summary>
        /// Gets the collateral by credit agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/collateral")]
        [ResponseType(typeof(IEnumerable<BusinessLayer.Models.Presentation.Responses.Collateral.Collateral>))]
        public async Task<HttpResponseMessage> GetCollateralByCreditAgreement(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));

            try
            {
                var collateral = await _service.GetCollateralAsync(id);
                if (collateral == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, collateral.Select(c => (BusinessLayer.Models.Presentation.Responses.Collateral.Collateral)c));
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Determines whether the specified identifier is exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("exists/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<HttpResponseMessage> IsExists(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));

            try
            {
                var collateral = await _service.IsExists(id);

                return Request.CreateResponse(HttpStatusCode.OK, collateral);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets the collaterals by agreement identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/collaterals")]
        [ResponseType(typeof(IEnumerable<BusinessLayer.Models.Presentation.Responses.Collateral.Collateral>))]
        public async Task<HttpResponseMessage> GetCollateralsByAgreementId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));


            var collateralAgreements = await _service.GetCollateralsByAgreementIdAsync(id);
            if (collateralAgreements == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, collateralAgreements.Select(c => (BusinessLayer.Models.Presentation.Responses.Collateral.Collateral)c));
        }
    }
}