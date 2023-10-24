using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SuperAdmin: User
    {
        public ICollection<Admin> AdminModified { get; set; } = new List<Admin>();

    }
}
