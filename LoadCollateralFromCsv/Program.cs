using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CollateralService.ApiClient.Client;
using CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral;
using Microsoft.Rest;
using LoadCollateralFromCsv.Models.Maps;
using System.Globalization;
using System.Collections.Concurrent;

namespace LoadCollateralFromCsv
{
    enum CurrencyCodes { UAH = 980, EUR = 978, USD = 840, CHF = 756 }

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(@"e:\Projects\AC_Collateral\2017_06_18_Залоги_1.csv"))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.Encoding = Encoding.UTF8;
                csv.Configuration.RegisterClassMap(new CollateralMap());
                var credentials = new BasicAuthenticationCredentials();
                credentials.UserName = ConfigurationManager.AppSettings["CollateralServiceApiLogin"];
                credentials.Password = ConfigurationManager.AppSettings["CollateralServiceApiPassword"];
                var service = new CollateralServiceWebAPI(new Uri(ConfigurationManager.AppSettings["CollateralServiceApi"]), credentials);

                var collateral = csv.GetRecords<Models.Collateral>()
                    .Where(i => !string.IsNullOrEmpty(i.CollateralAgreementId) && i.CollateralAgreementId != "#N/A" && i.Type != "NO" && i.Type != "not need")
                    .ToList();

                ConcurrentDictionary<string, Evaluation> evalutionList = new ConcurrentDictionary<string, Evaluation>();
                //collateral.ToList().ForEach(item =>
                Parallel.ForEach(collateral, new ParallelOptions { MaxDegreeOfParallelism = 10 }, item =>
                {
                    switch (item.Type)
                    {
                        case "AUTO":
                            {
                                var car = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Car
                                {
                                    Subtype = new Subtype { Name = item.Subtype },
                                    Description = item.Description,
                                    Brand = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Brand { Name = item.Brand },
                                    Model = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Model { Name = item.Model },
                                    VinCode = item.VinCode,
                                    Color = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Color { Name = item.Color },
                                    StateNumber = item.StateNumber,
                                    YearIssue = item.YearIssue,
                                    Region = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Car.Region { Name = item.CarRegion },
                                    Type = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Type { Name = item.Type },
                                    IsActive = true,
                                    User = "system"
                                };
                                car.EvaluationHistory = new List<Evaluation> { new Evaluation { Date = DateTime.Today, Source = new Source { Name = "Б2" }, Value = new Amount { Value = (double)item.Price / 100, Currency = new Currency { Name = ((CurrencyCodes)item.Currency).ToString() } } } };
                                var startTime = DateTime.Now;
                                try
                                {
                                    service.Collateral.PostCarToCollateralAgreement(item.CollateralAgreementId, car);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                car = null;
                                var endTime = DateTime.Now;
                                Console.WriteLine($"Start: {startTime} End: {endTime} Duration: {(endTime - startTime).TotalSeconds}");
                            }
                            break;
                        case "OTHER":
                            {
                                var other = new CollateralService.ApiClient.Client.Models.Presentation.Requests.OtherCollateral.OtherCollateral
                                {
                                    Description = item.Description,
                                    Type = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Type { Name = item.Type },
                                    IsActive = true,
                                    User = "system"
                                };
                                other.EvaluationHistory = new List<Evaluation> { new Evaluation { Date = DateTime.Today, Source = new Source { Name = "Б2" }, Value = new Amount { Value = (double)item.Price / 100, Currency = new Currency { Name = ((CurrencyCodes)item.Currency).ToString() } } } };
                                var startTime = DateTime.Now;
                                try
                                {
                                    service.Collateral.PostOtherCollateralToCollateralAgreement(item.CollateralAgreementId, other);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                other = null;
                                var endTime = DateTime.Now;
                                Console.WriteLine($"Start: {startTime} End: {endTime} Duration: {(endTime - startTime).TotalSeconds}");
                            }
                            break;
                        default:
                            {
                                var mortage = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Mortgage
                                {
                                    Region = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Region { Name = item.MortageRegion },
                                    District = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.District { Name = item.District },
                                    Settlement = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Mortgage.Settlement { Name = item.City },
                                    Street = item.Street,
                                    House = item.House,
                                    Apartment = item.Flat,
                                    NumberOfRooms = item.Rooms,
                                    Type = new CollateralService.ApiClient.Client.Models.Presentation.Requests.Collateral.Type { Name = item.Type },
                                    IsActive = true,
                                    Description = item.Description,
                                    TotalArea = item.TotalArea.ToString(),
                                    LandArea = item.LandArea.ToString(),
                                    User = "system"
                                };
                                mortage.EvaluationHistory = new List<Evaluation> { new Evaluation { Date = DateTime.Today, Source = new Source { Name = "Б2" }, Value = new Amount { Value = (double)item.Price / 100, Currency = new Currency { Name = ((CurrencyCodes)item.Currency).ToString() } } } };
                                var startTime = DateTime.Now;
                                try
                                {
                                    service.Collateral.PostMortgageToCollateralAgreement(item.CollateralAgreementId, mortage);
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine(e.Message);
                                }

                                mortage = null;
                                var endTime = DateTime.Now;
                                Console.WriteLine($"Start: {startTime} End: {endTime} Duration: {(endTime - startTime).TotalSeconds}");
                            }
                            break;
                    }
                });
                Console.ReadLine();
            }
        }
    }
}