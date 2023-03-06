using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Data.Dtos.User
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo senha não deve ultrapassar 30 caracteres")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [Range(0, 99999999999, ErrorMessage = "CPF inválido")]
        public double Cpf { get; set; }
    }
}
