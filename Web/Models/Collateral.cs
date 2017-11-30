using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Collateral
    {
        public string Id { get; set; }
        public Type Type { get; set; }
        public Subtype Subtype { get; set; }
        [DisplayName("Описнаие")]
        public string Description { get; set; }
        [DisplayName("Удален")]
        public bool Deleted { get; set; }
        [DisplayName("Оценка")]
        public Amount Value { get; set; }
        [DisplayName("Дата оценки")]
        public DateTime EvaluationDate { get; set; }
        [DisplayName("Статус")]
        public Status Status { get; set; }
        [DisplayName("Активный")]
        public bool IsActive { get; set; }
        [DisplayName("Мараторий")]
        public bool IsMoratorium { get; set; }
        [DisplayName("Продан")]
        public bool IsSale { get; set; }
        [DisplayName("Проверен")]
        public bool IsVerified { get; set; }
    }
}