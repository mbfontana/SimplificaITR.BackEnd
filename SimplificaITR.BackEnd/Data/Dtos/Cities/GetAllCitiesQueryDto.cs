using System.ComponentModel.DataAnnotations;

namespace SimplificaITR.BackEnd.Data.Dtos.Cities
{
    public class GetAllCitiesQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public int Font { get; set; }
        public string Type { get; set; } = null!;
        public double Value { get; set; }
    }
}
