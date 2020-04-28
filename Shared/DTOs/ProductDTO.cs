using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public partial class ProductDTO
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        [Required]
        public bool IsDiscontinued { get; set; }
    }
}
