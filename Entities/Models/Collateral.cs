using Newtonsoft.Json.Linq;
using Repository.Pattern.Ef6;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Collateral : Entity
    {
        private string id;

        public string Id
        {
            get
            {
                return id ?? (id = Guid.NewGuid().ToString());
            }
            set
            {
                id = value;
            }
        }
        public string Body { get; set; }
        public string History { get; set; }
        public string Location { get; set; }
        public ICollection<CollateralAgreement> CollateralAgreements { get; set; }
        public ICollection<CreditAgreement> CreditAgreements { get; set; }

        public Collateral()
        {
            CollateralAgreements = new List<CollateralAgreement>();
        }
    }
}
