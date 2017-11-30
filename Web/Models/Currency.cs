using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Currency : Dictionary
    {
        [DisplayName("Валюта")]
        public override string Name { get; set; }
    }
}