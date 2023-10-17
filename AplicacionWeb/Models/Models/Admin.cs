using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Admin
    {
        public ICollection<Products> PublishedProducts { get; set; } = new List<Products>();
    }
}
