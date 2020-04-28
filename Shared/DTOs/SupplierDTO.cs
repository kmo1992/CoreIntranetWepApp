using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public partial class SupplierDTO
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string ContactName { get; set; }
        [MaxLength(40)]
        public string ContactTitle { get; set; }
        [MaxLength(40)]
        public string City { get; set; }
        [MaxLength(40)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Fax { get; set; }
    }
}
