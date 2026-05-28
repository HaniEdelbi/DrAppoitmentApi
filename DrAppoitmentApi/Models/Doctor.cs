using System.ComponentModel.DataAnnotations;

namespace DrAppoitmentApi.Models
{
    public class Doctor
    {


        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Specialty { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Region { get; set; } = string.Empty;

    }
}
