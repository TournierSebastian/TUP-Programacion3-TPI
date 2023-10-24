using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SellOrder
    {
        public int idOrder { get; set; }
        public string? PayMethod { get; set; }

        public int TotalValue { get; set; }
    }
}
