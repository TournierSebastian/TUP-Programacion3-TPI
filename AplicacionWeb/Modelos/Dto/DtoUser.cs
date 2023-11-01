using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


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

        public string Role { get; set; }
    }
}
