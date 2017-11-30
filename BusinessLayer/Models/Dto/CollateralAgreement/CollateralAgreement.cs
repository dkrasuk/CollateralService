using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.CollateralAgreement
{
    public class CollateralAgreement
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string PersonId { get; set; }

        public static implicit operator CollateralAgreement(Entities.Models.CollateralAgreement agreement)
        {
            return Mapper.Map<Entities.Models.CollateralAgreement, CollateralAgreement>(agreement); ;
        }

        public static implicit operator Models.Presentation.Responses.CollateralAgreement.CollateralAgreement(CollateralAgreement agreement)
        {
            return Mapper.Map<CollateralAgreement, Presentation.Responses.CollateralAgreement.CollateralAgreement>(agreement); ;
        }
    }
}
