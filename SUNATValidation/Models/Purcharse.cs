using System.ComponentModel.DataAnnotations;

namespace SUNATValidation.Models
{
    public class Purcharse
    {
        [Key]
        public int Id { get; set; }
        public string NumRegistro { get; set; }
        public string FechaComp { get; set; }
        public string TipoComp { get; set; }
        public string SerieComp { get; set; }
        public int NumComp { get; set; }
        public int? TipoDocSN { get; set; }
        public string? NumDocSN { get; set; }
        public double DocTotal { get; set; }
        public double? DocRate { get; set; }

    }
}
