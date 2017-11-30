using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer.Interfaces;
using Repository.Pattern.UnitOfWork;
using WebApi.Filters;
using System.Collections.Generic;
using Newtonsoft.Json;
using GoogleMapService.BusinessLayer;
using System.Configuration;

namespace WebApi.Controllers
{
    /// <summary>
    /// Collateral Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("collateral")]
    [CustomExceptionFilter]
    public class CollateralController : ApiController
    {
        private readonly ICollateralService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IGetGeoCodeService _geo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollateralController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="unitOfWorkAsync">The unit of work asynchronous.</param>
        /// <param name="geo">The geo.</param>
        public CollateralController(ICollateralService service, IUnitOfWorkAsync unitOfWorkAsync, IGetGeoCodeService geo)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _geo = geo;
        }

        /// <summary>
        /// Gets the collateral by collateral identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.Collateral.Collateral))]
        public async Task<HttpResponseMessage> GetCollateralByCollateralId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetCollateralByCollateralIdAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var responseObj = (BusinessLayer.Models.Presentation.Responses.Collateral.Collateral)collateralObj;

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);

        }

        /// <summary>
        /// Gets the evaluation by collateral identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}/getevaluation")]
        [ResponseType(typeof(List<BusinessLayer.Models.Presentation.Responses.Collateral.Evaluation>))]
        public async Task<HttpResponseMessage> GetEvaluationByCollateralId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetEvaluationByCollateralIdAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, collateralObj);

        }

        /// <summary>
        /// Gets the location by collateral identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}/location")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.Collateral.Location))]
        public async Task<HttpResponseMessage> GetLocationByCollateralId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetLocationCollateralIdAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var responseObj = JsonConvert.DeserializeObject<BusinessLayer.Models.Presentation.Responses.Collateral.Location>(collateralObj);

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);

        }


        /// <summary>
        /// Posts the location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/setlocation")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostLocation(string id, [FromBody]BusinessLayer.Models.Presentation.Requests.Collateral.Location location)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            try
            {
                var dtoLocation = (BusinessLayer.Models.Dto.Collateral.Location)location;
                await _service.PostLocationAsync(id, dtoLocation);
                await _unitOfWorkAsync.SaveChangesAsync();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        /// <summary>
        /// Gets the agreement identifier by collateral identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/listagreementId")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<HttpResponseMessage> GetAgreementIdByCollateralId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            try
            {
                var listAgreemId = await _service.GetAgreementIdByCollateralIdAsync(id);
                if (listAgreemId == null)
                {
                    Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, listAgreemId);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Posts the evaluation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="evaluation">The evaluation.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/evaluation")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostEvaluation(string id, [FromBody]BusinessLayer.Models.Presentation.Requests.Collateral.Evaluation evaluation)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            try
            {

                var dtoEvaluation = (BusinessLayer.Models.Dto.Collateral.Evaluation)evaluation;
                var evaluationId = await _service.PostEvaluationAsync(id, dtoEvaluation);
                await _unitOfWorkAsync.SaveChangesAsync();
                if (evaluationId == null)
                {
                    Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, evaluationId);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        /// <summary>
        /// Deletes the collateral.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userlogin">The userlogin.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<HttpResponseMessage> DeleteCollateral(string id, string userlogin)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            try
            {
                var res = await _service.DeleteCollateralAsync(id, userlogin);
                await _unitOfWorkAsync.SaveChangesAsync();

                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        /// <summary>
        /// Puts the collateral links.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newCollateralAgreementId">The new collateral agreement identifier.</param>
        /// <param name="oldCollateralAgreementId">The old collateral agreement identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/changelink")]
        [ResponseType(typeof(bool))]
        public async Task<HttpResponseMessage> PutCollateralLinks(string id, string newCollateralAgreementId, string oldCollateralAgreementId)
        {
            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(newCollateralAgreementId) && string.IsNullOrEmpty(oldCollateralAgreementId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var res = await _service.ChangeCollateralLinks(id, newCollateralAgreementId, oldCollateralAgreementId);
            await _unitOfWorkAsync.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        #region Car
        /// <summary>
        /// Gets the car details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("car/{id}")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.Car.Car))]
        public async Task<HttpResponseMessage> GetCarDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetCarDetailsAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var responseObj = (BusinessLayer.Models.Presentation.Responses.Car.Car)collateralObj;

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);

        }

        /// <summary>
        /// Posts the car to collateral agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("collateralagreement/{id}/car")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostCarToCollateralAgreement(string id, [FromBody]BusinessLayer.Models.Presentation.Requests.Car.Car collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Car.Car)collateral;
            string responseObj = await _service.PostCollateralToCollateralAgreementAsync(id, dtoCollateral);
            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");

            await _unitOfWorkAsync.SaveChangesAsync();

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }


            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Posts the car to credit agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("creditagreement/{id}/car")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostCarToCreditAgreement(string id, [FromBody]BusinessLayer.Models.Presentation.Requests.Car.Car collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Car.Car)collateral;
            string responseObj = await _service.PostCollateralToCreditagreementAsync(id, dtoCollateral);
            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");

            await _unitOfWorkAsync.SaveChangesAsync();


            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Puts the car.
        /// </summary>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("car/")]
        public async Task<HttpResponseMessage> PutCar(BusinessLayer.Models.Presentation.Requests.Car.Car collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Car.Car)collateral;
            dtoCollateral.ModifyDate = DateTime.UtcNow;
            await _service.PutCollateralAsync(dtoCollateral);

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(dtoCollateral.Id, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
        #endregion

        #region Mortgage
        /// <summary>
        /// Gets the mortgage details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("mortgage/{id}")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.Mortgage.Mortgage))]
        public async Task<HttpResponseMessage> GetMortgageDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetMortgageDetailsAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var responseObj = (BusinessLayer.Models.Presentation.Responses.Mortgage.Mortgage)collateralObj;

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Posts the mortgage to collateral agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("collateralagreement/{id}/mortgage")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostMortgageToCollateralAgreement(string id, BusinessLayer.Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Mortgage.Mortgage)collateral;
            string responseObj = await _service.PostCollateralToCollateralAgreementAsync(id, dtoCollateral);
            await _unitOfWorkAsync.SaveChangesAsync();
            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.Settlement.Name) && !string.IsNullOrEmpty(dtoCollateral.Street))
            {
                string address = string.Format(dtoCollateral.Region.Name + ", " + dtoCollateral.SettlementType.Name + " " + dtoCollateral.Settlement.Name + ", " + dtoCollateral.Street + " " + dtoCollateral.House);
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, address);
            }


            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Posts the mortgage to creditagreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("creditagreement/{id}/mortgage")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostMortgageToCreditagreement(string id, BusinessLayer.Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Mortgage.Mortgage)collateral;
            string responseObj = await _service.PostCollateralToCreditagreementAsync(id, dtoCollateral);
            await _unitOfWorkAsync.SaveChangesAsync();
            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.Settlement.Name) && !string.IsNullOrEmpty(dtoCollateral.Street))
            {
                string address = string.Format(dtoCollateral.Region.Name + ", " + dtoCollateral.SettlementType.Name + " " + dtoCollateral.Settlement.Name + ", " + dtoCollateral.Street + " " + dtoCollateral.House);
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, address);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Puts the mortgage.
        /// </summary>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("mortgage/")]
        public async Task<HttpResponseMessage> PutMortgage(BusinessLayer.Models.Presentation.Requests.Mortgage.Mortgage collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.Mortgage.Mortgage)collateral;

            dtoCollateral.ModifyDate = DateTime.UtcNow;
            await _service.PutCollateralAsync(dtoCollateral);


            if (!string.IsNullOrEmpty(collateral.Settlement.Name) && !string.IsNullOrEmpty(collateral.Street))
            {
                string address = string.Format(collateral.Region.Name + ", " + collateral.SettlementType.Name + " " + collateral.Settlement.Name + ", " + collateral.Street + " " + collateral.House);
                await СheckingAndPostGeoLocation(dtoCollateral.Id, dtoCollateral.Type, address);
            }

            await _unitOfWorkAsync.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        #region Other Collateral
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>    
        [HttpGet]
        [Route("other/{id}")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.OtherCollateral.OtherCollateral))]
        public async Task<HttpResponseMessage> GeOtherCollateralDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("id"));
            try
            {
                Guid.Parse(id);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var collateralObj = await _service.GetOtherCollateralDetailsAsync(id);
            if (collateralObj == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var responseObj = (BusinessLayer.Models.Presentation.Responses.OtherCollateral.OtherCollateral)collateralObj;

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Posts the other collateral to collateral agreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("collateralagreement/{id}/other")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostOtherCollateralToCollateralAgreement(string id, BusinessLayer.Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.OtherCollateral.OtherCollateral)collateral;
            string responseObj = await _service.PostCollateralToCollateralAgreementAsync(id, dtoCollateral);
            await _unitOfWorkAsync.SaveChangesAsync();

            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Posts the other collateral to creditagreement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("creditagreement/{id}/other")]
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> PostOtherCollateralToCreditagreement(string id, BusinessLayer.Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.OtherCollateral.OtherCollateral)collateral;
            string responseObj = await _service.PostCollateralToCreditagreementAsync(id, dtoCollateral);
            await _unitOfWorkAsync.SaveChangesAsync();

            if (string.IsNullOrEmpty(responseObj))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ошибка при создании залога");
            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(responseObj, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseObj);
        }

        /// <summary>
        /// Puts the other collateral.
        /// </summary>
        /// <param name="collateral">The collateral.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("other/")]
        public async Task<HttpResponseMessage> PutOtherCollateral(BusinessLayer.Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            if (collateral == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ArgumentNullException("collateral"));

            var dtoCollateral = (BusinessLayer.Models.Dto.OtherCollateral.OtherCollateral)collateral;
            dtoCollateral.ModifyDate = DateTime.UtcNow;
            await _service.PutCollateralAsync(dtoCollateral);

            //GEO
            if (!string.IsNullOrEmpty(dtoCollateral.RegistrationClientAddress))
            {
                await СheckingAndPostGeoLocation(dtoCollateral.Id, dtoCollateral.Type, dtoCollateral.RegistrationClientAddress);
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion

        #region GeoLocation
        /// <summary>
        /// Сheckings the and post geo location.
        /// </summary>
        /// <param name="collateralId">The collateral identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public async Task<string> СheckingAndPostGeoLocation(string collateralId, string type, string address)
        {
            BusinessLayer.Models.Dto.Collateral.Location item;
            var location = _service.GetLocationCollateralIdAsync(collateralId).Result;
            String oldAddress = location?.Address;

            if ((location == null) || ((location != null) && !oldAddress.Contains(address)))
            {
                string apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
                try
                {
                    var geoLocation = _geo.GetGeoLocations(address, apiKey);
                    item = geoLocation.Result.ToObject<BusinessLayer.Models.Dto.Collateral.Location>();
                    item.Address = address;
                    item.Type = type;
                    await _service.PostLocationAsync(collateralId, item);
                    await _unitOfWorkAsync.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return collateralId;
        }

        /// <summary>
        /// Geoes the by address and post location. Тестовый метод для swagger, аналог "СheckingAndPostGeoLocation" 
        /// </summary>
        /// <param name="collateralId">The collateral identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("geogooglesavetocollateral")]
        [ResponseType(typeof(BusinessLayer.Models.Presentation.Responses.Collateral.Location))]
        public async Task<HttpResponseMessage> GeoByAddressAndPostLocation(string collateralId, string type, string address)
        {
            string apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
            if (string.IsNullOrEmpty(collateralId) && string.IsNullOrEmpty(type) && string.IsNullOrEmpty(address))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                Guid.Parse(collateralId);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            var geoLocation = _geo.GetGeoLocations(address, apiKey);
            var item = geoLocation.Result.ToObject<BusinessLayer.Models.Dto.Collateral.Location>();
            item.Address = address;
            item.Type = type;
            await _service.PostLocationAsync(collateralId, item);
            await _unitOfWorkAsync.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        /// <summary>
        /// Gets all agreement identifier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listallagreemsid")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<HttpResponseMessage> GetAllAgreementId()
        { 
            try
            {
                var listAgreemId = await _service.GetAllAgreementsIdAsync();
                if (listAgreemId == null)
                {
                    Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, listAgreemId);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        #endregion 

    }
}