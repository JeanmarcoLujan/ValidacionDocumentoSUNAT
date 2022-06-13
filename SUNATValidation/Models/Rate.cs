using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SUNATValidation.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateRate { get; set; }
        public double Purchase { get; set; }
        public double Sale { get; set; }

    }
}
