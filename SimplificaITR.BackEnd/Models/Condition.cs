using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplificaITR.BackEnd.Models
{
    public class Condition
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public double Value { get; set; }

        [ForeignKey("City")]
        [Required]
        public int CityId { get; set; }

        public virtual List<Area> Areas { get; set; } = null!;
    }
}
