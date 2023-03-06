using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Models
{
    public class Area
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public double Metreage { get; set; }

        public virtual Property Property { get; set; } = null!;

        [Required]
        public int PropertyId { get; set; }

        public virtual Condition Condition { get; set; } = null!;

        [Required]
        public int ConditionId { get; set; }
    }
}
