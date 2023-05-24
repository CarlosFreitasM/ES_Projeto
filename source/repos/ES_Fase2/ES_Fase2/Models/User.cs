using System.ComponentModel.DataAnnotations;

namespace ES_Fase2.Models
{
    
    public class User
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        [Required]
        public string Nome { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Autenticado { get; set; }
    }
}
