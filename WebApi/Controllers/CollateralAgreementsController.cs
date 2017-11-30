using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer.Interfaces;
using Repository.Pattern.UnitOfWork;
using WebApi.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// Collateral Agreements Controller
    /// </summary>
    [RoutePrefix("collateralAgreement")]
    [CustomExceptionFilter]
    public class CollateralAgreementsController : ApiController
    {
        private readonly ICollateralAgreementService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollateralAgreementsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="unitOfWorkAsync">The unit of work asynchronous.</param>
        public CollateralAgreementsController(ICollateralAgreementService service, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        /// <summary>
        /// Gets the collateral by collateral agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}/collateral")]
        [ResponseType(typeof(IEnumerable<BusinessLayer.Models.Presentation.Responses.Collateral.Collateral>))]
        public async Task<HttpResponseMessage> GetCollateralByCollateralAgreement(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));

            try
            {
                var collateral = await _service.GetCollateralAsync(id);
                if (collateral == null)
                {
                    Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, collateral.Select(c=>(BusinessLayer.Models.Presentation.Responses.Collateral.Collateral)c));
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
    }
}