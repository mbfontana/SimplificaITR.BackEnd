using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Models
{
    public class Property
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public double Nirf { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("City")]
        [Required]
        public int CityId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;

        public virtual City City { get; set; } = null!;

        public virtual List<Area> Areas { get; set; } = null!;
    }
}
