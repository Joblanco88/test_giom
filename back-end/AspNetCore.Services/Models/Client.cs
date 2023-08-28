using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Services.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        [StringLength(80)]
        public string? Phone { get; set; }
    }
}
