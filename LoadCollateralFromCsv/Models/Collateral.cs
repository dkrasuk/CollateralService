using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCollateralFromCsv.Models
{
    public class Collateral
    {
        public string CollateralAgreementId { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public string Color { get; set; }
        public string StateNumber { get; set; }
        public int? YearIssue { get; set; }
        public string CarRegion { get; set; }
        public decimal Price { get; set; }
        public int Currency { get; set; }
        public string MortageRegion { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public int? Rooms { get; set; }
        public double? TotalArea { get; set; }
        public double? LandArea { get; set; }
    }
}
