namespace SimplificaITR.BackEnd.Data.Dtos.Cities
{
    public class GetAllCitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public double AptidaoBoa { get; set; }
        public double AptidaoRegular { get; set; }
        public double AptidaoRestrita { get; set; }
        public double PastagemPlantada { get; set; }
        public double Silvicultura { get; set; }
        public double Preservacao { get; set; }
        public int Font { get; set; }
    }
}
