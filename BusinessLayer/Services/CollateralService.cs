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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BusinessLayer.Models.Dto.Car;
using BusinessLayer.Models.Dto.Mortgage;
using BusinessLayer.Models.Dto.OtherCollateral;

namespace BusinessLayer
{
    class CollateralService : Service<Collateral>, ICollateralService
    {
        private readonly IRepositoryAsync<Collateral> _repository;      


        public CollateralService(IRepositoryAsync<Collateral> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Models.Dto.Collateral.Collateral> GetCollateralByCollateralIdAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (collateral == null)
            {
                return null;
            }
            return collateral;
        }

        public async Task<List<Models.Dto.Collateral.Evaluation>> GetEvaluationByCollateralIdAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (collateral == null)
            {
                return null;
            }
            var evaluationList = new List<Models.Dto.Collateral.Evaluation>();
            string json = collateral.Body;
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            JObject jobject = JObject.Parse(json);

            var evaluation = jobject["EvaluationHistory"].Children();
            foreach (var item in evaluation)
            {
                var i = item.ToObject<BusinessLayer.Models.Dto.Collateral.Evaluation>();
                evaluationList.Add(i);
            }
            return evaluationList;
        }

        public async Task<IEnumerable<string>> GetAgreementIdByCollateralIdAsync(string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                var collateralAgreements = _repository.Queryable()
               .Include(c => c.CollateralAgreements)
               .Where(x => x.Id == id)
               .SelectMany(x => x.CollateralAgreements);

                var creditAgreementsList = collateralAgreements.Include(i => i.CreditAgreements).SelectMany(p => p.CreditAgreements);

                if (creditAgreementsList.Count() > 0)
                    return creditAgreementsList.Select(c => c.Id).ToList();

                return new List<string>();

            });
        }

        //Получить List AgreementId
        public async Task<IEnumerable<string>> GetAllAgreementsIdAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                var collateralAgreements = _repository.Queryable()
               .Include(c => c.CollateralAgreements)
               .Where(x => x.Location != null)
               .SelectMany(x => x.CollateralAgreements);

                var creditAgreementsList = collateralAgreements.Include(i => i.CreditAgreements).Where(x => x.CloseDate == null).SelectMany(p => p.CreditAgreements);

                if (creditAgreementsList.Count() > 0)
                {                    
                    return creditAgreementsList.Select(c => c.Id).Distinct().ToList();
                }                

                return new List<string>();
            });
        }



        public async Task<Car> GetCarDetailsAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (collateral == null)
                return null;

            var dtoCar = (Car)collateral;

            return dtoCar;
        }

        public async Task<Mortgage> GetMortgageDetailsAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (collateral == null)
                return null;

            var dtoMortgage = (Mortgage)collateral;

            return dtoMortgage;
        }

        public async Task<OtherCollateral> GetOtherCollateralDetailsAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (collateral == null)
                return null;

            var dtoMortgage = (OtherCollateral)collateral;

            return dtoMortgage;
        }

        public async Task PutCollateralAsync(Models.Dto.Collateral.Collateral collateral)
        {
            var dbCollateral = await _repository.FindAsync(collateral.Id);
            if (dbCollateral == null)
                throw new KeyNotFoundException(string.Format("There is no collateral with specified id {0}", collateral.Id));

            collateral.ActualDescription = GenerateActualDescription(collateral);
            collateral.ModifyDate = DateTime.UtcNow;

            var diffs = GetJsonDiff(dbCollateral.Body, collateral);
            SetHistory(dbCollateral, diffs);

            dbCollateral.Body = MergeJObject(dbCollateral.Body, collateral);

            _repository.Update(dbCollateral);
        }


        public async Task<string> PostCollateralToCollateralAgreementAsync(string collateralAgreementId, Models.Dto.Collateral.Collateral collateral)
        {
            var newCollateral = PrepareNewCollateral(collateral);

            CollateralAgreement collagreement = new CollateralAgreement { Id = collateralAgreementId };
            newCollateral.CollateralAgreements = new List<CollateralAgreement>() { collagreement };

            _repository.Insert(newCollateral);

            return newCollateral.Id;
        }

        public async Task<BusinessLayer.Models.Dto.Collateral.Location> GetLocationCollateralIdAsync(string id)
        {
            var collateral = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            var json = collateral.Location;

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            var location = JsonConvert.DeserializeObject<BusinessLayer.Models.Dto.Collateral.Location>(json);

            return location;
        }

        public async Task PostLocationAsync(string id, Models.Dto.Collateral.Location location)
        {
            var dbLocation = await _repository.Queryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbLocation == null)
                throw new KeyNotFoundException(string.Format("There is no collateral with specified id {0}", id));
            dbLocation.Location = JsonConvert.SerializeObject(location);
            _repository.Update(dbLocation);
        }
        public async Task<string> PostCollateralToCreditagreementAsync(string creditAgreementId, Models.Dto.Collateral.Collateral collateral)
        {
            var newCollateral = PrepareNewCollateral(collateral);

            CreditAgreement creditagreement = new CreditAgreement { Id = creditAgreementId };
            newCollateral.CreditAgreements = new List<CreditAgreement>() { creditagreement };

            _repository.Insert(newCollateral);

            return newCollateral.Id;
        }

        private Collateral PrepareNewCollateral(Models.Dto.Collateral.Collateral collateral)
        {
            Entities.Models.Collateral newCollateral = new Collateral();
            collateral.Id = newCollateral.Id;
            collateral.ActualDescription = GenerateActualDescription(collateral);
            collateral.EntryDate = DateTime.UtcNow;

            newCollateral.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
            newCollateral.Body = collateral;

            SetHistory(newCollateral, collateral);

            return newCollateral;
        }

        private string GenerateActualDescription(Models.Dto.Collateral.Collateral collateral)
        {
            StringBuilder res = new StringBuilder();

            switch (collateral.Type.Name)
            {
                case "COMMERCIAL":
                case "HOME":
                case "LAND":
                    var t = (Mortgage)collateral;

                    res.Append(t.Region?.Name)
                        .Append(", ").Append(t.District?.Name)
                        .Append(", ").Append(t.SettlementType?.Name)
                        .Append(", ").Append(t.Settlement?.Name)
                        .Append(", ").Append(t.Street)
                        .Append(", ").Append(t.House)
                        .Append(", ").Append(t.Apartment)
                        .Append("; общая площадь: = ").Append(t.TotalArea);

                    break;
                case "FLAT":
                    var f = (Mortgage)collateral;
                    res.Append(f.Region?.Name)
                        .Append(", ").Append(f.District?.Name)
                        .Append(", ").Append(f.SettlementType?.Name)
                        .Append(", ").Append(f.Settlement?.Name)
                        .Append(", ").Append(f.Street)
                        .Append(", ").Append(f.House)
                        .Append(", ").Append(f.Apartment)
                        .Append("; кол-во комнат: = ").Append(f.NumberOfRooms)
                        .Append("; общая площадь: = ").Append(f.TotalArea);

                    break;
                case "AUTO":
                    var a = (Car)collateral;
                    res.Append(a.Brand?.Name)
                        .Append(" ").Append(a.Model?.Name)
                        .Append("; гос. номер: ").Append(a.StateNumber)
                        .Append("; номер кузова: ").Append(a.VinCode)
                        .Append("; Год выпуска: ").Append(a.YearIssue);

                    break;
                case "OTHER":
                    var o = (OtherCollateral)collateral;
                    res.Append(o.Specification);

                    break;
            }

            return res.ToString();
        }

        #region EvaluationHistory
        //public async Task<string> PostEvaluationAsync(string id, Models.Dto.Collateral.Evaluation evaluation)
        //{
        //    var dbCollateral = await _repository.FindAsync(id);
        //    if (dbCollateral == null)
        //        throw new KeyNotFoundException(string.Format("There is no collateral with specified id {0}", id));

        //    var evaluationHistory = evaluation;  // new { EvaluationHistory = new List<Models.Dto.Collateral.Evaluation>() { evaluation } };
        //    var evaluationItem = new
        //    {
        //        Evaluation = new Models.Dto.Collateral.Evaluation
        //        {
        //            Date = evaluation.Date,
        //            DateEntry = evaluation.DateEntry,
        //            Responsible = evaluation.Responsible,
        //            Source = evaluation.Source,
        //            Type = evaluation.Type,
        //            Value = evaluation.Value
        //        }
        //    };

        //    SetEvaluationHistory(dbCollateral, evaluationHistory);

        //    Models.Dto.Collateral.Collateral evalBodyOld = dbCollateral;
        //    if (evalBodyOld.Evaluation == null)
        //    {
        //        dbCollateral.Body = MergeJObject(dbCollateral.Body, evaluationItem);
        //    }
        //    else if (evaluationItem.Evaluation.Date > evalBodyOld.Evaluation.Date)
        //    {
        //        dbCollateral.Body = MergeJObject(dbCollateral.Body, evaluationItem);
        //    }

        //    _repository.Update(dbCollateral);

        //    return evaluation.Id;
        //}
        #endregion

        public async Task<string> PostEvaluationAsync(string id, Models.Dto.Collateral.Evaluation evaluation)
        {
            var dbCollateral = await _repository.FindAsync(id);
            if (dbCollateral == null)
                throw new KeyNotFoundException(string.Format("There is no collateral with specified id {0}", id));

            var evaluationHistory = new { EvaluationHistory = new List<Models.Dto.Collateral.Evaluation>() { evaluation } };
            var evaluationItem = new
            {
                Evaluation = new Models.Dto.Collateral.Evaluation
                {
                    Date = evaluation.Date,
                    DateEntry = evaluation.DateEntry,
                    Responsible = evaluation.Responsible,
                    Source = evaluation.Source,
                    Type = evaluation.Type,
                    Value = evaluation.Value
                }
            };

            SetHistory(dbCollateral, evaluationHistory);

            Models.Dto.Collateral.Collateral evalBodyOld = dbCollateral;

            if (evalBodyOld.Evaluation == null)
            {
                dbCollateral.Body = MergeJObject(dbCollateral.Body, evaluationItem);
            }
            else if (evaluationItem.Evaluation.Date > evalBodyOld.Evaluation.Date || evaluationItem.Evaluation.Date == evalBodyOld.Evaluation.Date)
            {
                dbCollateral.Body = MergeJObject(dbCollateral.Body, evaluationItem);
            }

            dbCollateral.Body = MergeJObject(dbCollateral.Body, evaluationHistory);

            _repository.Update(dbCollateral);

            return evaluation.Id;
        }

        public async Task<bool> DeleteCollateralAsync(string id, string userlogin)
        {

            var dbCollateral = await _repository.FindAsync(id);
            if (dbCollateral == null)
                throw new KeyNotFoundException(string.Format("There is no collateral with specified id {0}", id));

            var collateral = new
            {
                Deleted = true,
                ModifyUser = userlogin
            };

            dbCollateral.Body = MergeJObject(dbCollateral.Body, collateral);

            SetHistory(dbCollateral, collateral);

            _repository.Update(dbCollateral);

            return true;
        }

        public async Task<bool> ChangeCollateralLinks(string id, string newCollateralAgreementId, string oldCollateralAgreementId)
        {
            var dbCollateral = await _repository.Queryable()
                                        .Include(i => i.CollateralAgreements)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            dbCollateral.CollateralAgreements.Add(new CollateralAgreement { Id = newCollateralAgreementId });
            var linkToDelete = dbCollateral.CollateralAgreements.FirstOrDefault(x => x.Id == oldCollateralAgreementId);

            dbCollateral.CollateralAgreements.Remove(linkToDelete);

            _repository.Update(dbCollateral);

            return true;
        }

        private string MergeJObject(string obj, object newObj)
        {
            var jObj = JObject.Parse(obj);
            var jNewObj = JObject.FromObject(newObj);

            jObj.Merge(jNewObj, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            });

            return jObj.ToString();
        }
        private JObject GetHistoryItem(object collateralObj)
        {
            var newObj = JObject.FromObject(collateralObj);

            dynamic historyItem = new JObject();
            dynamic collateral = new JObject();
            collateral = new JArray() { newObj };

            historyItem.CollateralHistory = collateral;

            return historyItem;
        }
        #region Get/Set EvaluationHistory
        //private JObject GetEvaluationHistoryItem(object collateralObj)
        //{
        //    var newObj = JObject.FromObject(collateralObj);

        //    dynamic evalHistoryItem = new JObject();
        //    dynamic collateral = new JObject();
        //    collateral = new JArray() { newObj };

        //    evalHistoryItem.EvaluationHistory = collateral;

        //    return evalHistoryItem;
        //}
        //private void SetEvaluationHistory(Collateral dbCollateral, object obj)
        //{
        //    string evalHistory = "";

        //    var evalHistoryItem = GetEvaluationHistoryItem(obj);

        //    if (!string.IsNullOrEmpty(dbCollateral.EvaluationHistory))
        //    {
        //        evalHistory = MergeJObject(dbCollateral.EvaluationHistory?.ToString(), evalHistoryItem);
        //    }
        //    else
        //    {
        //        var initEvalHistoryItem = new Models.Dto.Collateral.HistoryEvaluation() { EvaluationHistory = new List<Models.Dto.Collateral.Evaluation>() };
        //        evalHistory = MergeJObject(initEvalHistoryItem, evalHistoryItem);
        //    }
        //    dbCollateral.EvaluationHistory = evalHistory;
        //}
        #endregion

        private void SetHistory(Collateral dbCollateral, object obj)
        {
            string history = "";

            var historyItem = GetHistoryItem(obj);

            if (!string.IsNullOrEmpty(dbCollateral.History))
            {
                history = MergeJObject(dbCollateral.History?.ToString(), historyItem);
            }
            else
            {
                var initHistoryItem = new Models.Dto.Collateral.History() { CollateralHistory = new List<Models.Dto.Collateral.Collateral>() };
                history = MergeJObject(initHistoryItem, historyItem);
            }
            dbCollateral.History = history;
        }


        private JObject GetJsonDiff(string sourceObj, string modifiedObj)
        {
            var source = JObject.Parse(sourceObj);
            var modified = JObject.Parse(modifiedObj);

            var diff = SimpleHelpers.ObjectDiffPatch.GenerateDiff(source, modified);

            return diff.NewValues;
        }
    }
}
