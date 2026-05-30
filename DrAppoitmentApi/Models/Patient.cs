using System.ComponentModel.DataAnnotations;

namespace DrAppoitmentApi.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
