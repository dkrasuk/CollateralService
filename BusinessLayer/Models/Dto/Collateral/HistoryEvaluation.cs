using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.Collateral
{
    public class HistoryEvaluation
    {      
        public List<Evaluation> EvaluationHistory { get; set; }

        public static implicit operator string(HistoryEvaluation evaluation)
        {
            return JsonConvert.SerializeObject(evaluation);
        }

    }
}
