using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Amount
    {
        [DisplayName("Валюта")]
        public Currency Currency { get; set; }
        [DisplayName("Сумма")]

        public decimal Value { get; set; }
    }
}