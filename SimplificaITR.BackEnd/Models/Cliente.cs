using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public double CPF { get; set; }

        [Required]
        public virtual User User { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        public virtual List<Property> Properties { get; set; } = null!;
    }
}
