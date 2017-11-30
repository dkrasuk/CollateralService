using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Requests.Collateral
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

        public static implicit operator Evaluation(Dto.Collateral.Evaluation evaluation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Evaluation, Evaluation>());
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Amount, Amount>());
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Source, Source>());
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.EvalutionType, EvalutionType>());
            return Mapper.Map<Evaluation>(evaluation);

        }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Evaluation>();
        }
    }

    
}
