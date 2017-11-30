using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Dictionary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public static implicit operator string (Dictionary dictionary)
        {
            return dictionary.Name;
        }
    }
}
