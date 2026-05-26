using System.ComponentModel.DataAnnotations;

namespace DrAppoitmentApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;


    }
}
