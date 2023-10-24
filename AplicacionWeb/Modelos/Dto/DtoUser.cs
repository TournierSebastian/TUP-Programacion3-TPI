using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public class DtoUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idUser { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool Admin { get; set; }
    }
}
