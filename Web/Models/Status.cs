using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Status : Dictionary
    {
        [DisplayName("Статус")]
        public override string Name { get; set; }
    }
}