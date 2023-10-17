using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<Products> CartProducts { get; set; } = new List<Products>();
    }
}
