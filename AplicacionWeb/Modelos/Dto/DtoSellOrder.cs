using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
    public class DtoSellOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrder { get; set; }
        public string? PayMethod { get; set; }

        public int TotalValue { get; set; }
    }
}
