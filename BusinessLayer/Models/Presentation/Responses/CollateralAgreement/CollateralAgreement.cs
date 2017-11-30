using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Responses.CollateralAgreement
{
    public class CollateralAgreement
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string PersonId { get; set; }

    }
}
