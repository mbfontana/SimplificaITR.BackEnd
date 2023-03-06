using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Models
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(2)]
        public string State { get; set; } = null!;

        [Required]
        public int Font { get; set; }

        public virtual List<Condition> Conditions { get; set; } = null!;

        public virtual List<Property> Properties { get; set; } = null!;
    }
}
