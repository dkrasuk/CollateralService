using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace Entities.Models
{
    public class CreditAgreement : Entity
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
        public virtual ICollection<CollateralAgreement> CollateralAgreements { get; set; }
        public virtual ICollection<Collateral> OtherProperty { get; set; }
    }
}