using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public partial class OrderDTO
    {
        public int Id { get; private set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
