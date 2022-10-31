using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Models
{
    public class Condition
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        public virtual List<Area> Areas { get; set; } = null!;
    }
}
