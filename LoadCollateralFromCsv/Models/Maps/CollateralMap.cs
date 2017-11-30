using CsvHelper.Configuration;
using System;
using System.Text.RegularExpressions;

namespace LoadCollateralFromCsv.Models.Maps
{
    public class CollateralMap : CsvClassMap<Collateral>
    {
        public CollateralMap()
        {
            try
            {
                var intRegex = new Regex(@"\d+");
                var doubleRegex = new Regex(@"^[0-9]+(\,[0-9]+)?$");
                Map(m => m.CollateralAgreementId).Name("CollateralAgreementId");
                Map(m => m.Type).Name("TYPE");
                Map(m => m.Subtype).Name("SYB type");
                Map(m => m.Description).Name("description");
                Map(m => m.Brand).Name("car_brand_NEW");
                Map(m => m.Model).Name("model");
                Map(m => m.VinCode).Name("vin");
                Map(m => m.Color).Name("color true");
                Map(m => m.StateNumber).Name("state_number");
                Map(m => m.YearIssue).ConvertUsing(row => string.IsNullOrEmpty(row.GetField<string>("construction_year")) ? new int?() : int.Parse(intRegex.Match(row.GetField<string>("construction_year")).Value));
                Map(m => m.CarRegion).Name("car_registration_region");
                Map(m => m.Price).ConvertUsing(row => decimal.Parse(row.GetField<string>("B2_price").Replace(" ", "")));
                Map(m => m.Currency).Name("B2_currency");
                Map(m => m.MortageRegion).Name("region");
                Map(m => m.District).Name("district");
                Map(m => m.City).Name("city");
                Map(m => m.Street).Name("street");
                Map(m => m.House).Name("house");
                Map(m => m.Flat).Name("flat");
                Map(m => m.Rooms).ConvertUsing(row => string.IsNullOrEmpty(intRegex.Match(row.GetField<string>("rooms")).Value) ? new int?() : int.Parse(intRegex.Match(row.GetField<string>("rooms")).Value));
                Map(m => m.TotalArea).ConvertUsing(row => string.IsNullOrEmpty(doubleRegex.Match(row.GetField<string>("total_S").Replace(" ", "")).Value) ? new double?() : double.Parse(doubleRegex.Match(row.GetField<string>("total_S").Replace(" ", "")).Value));
                Map(m => m.LandArea).ConvertUsing(row => string.IsNullOrEmpty(doubleRegex.Match(row.GetField<string>("land_S").Replace(" ", "")).Value) ? new double?() : double.Parse(doubleRegex.Match(row.GetField<string>("land_S").Replace(" ", "")).Value));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
