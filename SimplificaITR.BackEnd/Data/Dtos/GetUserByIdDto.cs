using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Data.Dtos
{
    public class GetUserByIdDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo senha não deve ultrapassar 30 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [Range(0, 99999999999, ErrorMessage = "CPF inválido")]
        public double Cpf { get; set; }

        public DateTime RequestTime { get; set; }
    }
}
