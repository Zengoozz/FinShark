

using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage ="Symbol must be 10 characters max")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage ="Symbol must be 10 characters max")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage ="Symbol must be 10 characters max")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1,50000000000)]
        public long MarketCap { get; set; }
    }
}