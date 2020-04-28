using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public partial class OrderItemDTO
    {
        public int Id { get; private set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
