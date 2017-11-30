using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Responses.Collateral
{
    public class Evaluation
    {
        public string Id { get; set; }
        public Amount Value { get; set; }
        public DateTime Date { get; set; }
        public Source Source { get; set; }
        public string Responsible { get; set; }
        public DateTime DateEntry { get; set; }
        public EvalutionType Type { get; set; }

        public void DeserializeJson(JToken iListValue)
        {
            iListValue.ToObject<Evaluation>();
        }
    }
}
