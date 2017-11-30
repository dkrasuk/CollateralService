using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CollateralAgreement : Entity
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
        public string Number { get; set; }
        public DateTime? OpenDate { get;set; }
        public DateTime? CloseDate { get; set; }
        public string PersonId { get; set; }

        public virtual ICollection<Collateral> Collateral { get; set; }
        public virtual ICollection<CreditAgreement> CreditAgreements { get; set; }
    }
}
