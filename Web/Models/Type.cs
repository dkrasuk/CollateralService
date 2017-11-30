using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Type : Dictionary
    {
        [DisplayName("Тип")]
        public override string Name { get; set; }
    }
}