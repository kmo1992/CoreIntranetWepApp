using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public partial class CustomerDTO
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(40)]
        public string City { get; set; }
        [MaxLength(40)]
        public string Country { get; set; }
        [MaxLength(40)]
        public string Phone { get; set; }
    }
}
