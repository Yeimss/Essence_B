namespace Essence_B.Models.Domain.Perfums
{
    public class PerfumDto
    {
        public string Name { get; set; } = null!;

        public int? IdHouse { get; set; }

        public short? IdGender { get; set; }

        public short? IdOrigin { get; set; }

        public bool? Status { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }

        public short? IdConcentration { get; set; }
    }
}
