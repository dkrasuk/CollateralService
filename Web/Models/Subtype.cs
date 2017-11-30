using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Subtype : Dictionary
    {
        [DisplayName("Подтип")]
        public override string Name { get; set; }
    }
}