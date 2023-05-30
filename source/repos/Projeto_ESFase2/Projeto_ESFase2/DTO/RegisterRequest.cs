using System.ComponentModel.DataAnnotations;

namespace Projeto_ESFase2.DTO
{
    public class RegisterRequest
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public bool IsAdmin { get; set; }
    }
}
