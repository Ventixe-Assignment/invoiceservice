using System.ComponentModel.DataAnnotations;

namespace Presentaion.Models;

public class InvoiceRequest
{
    [Required]
    public string EventId { get; set; } = null!;
    [Required]
    public string UserId { get; set; } = null!;
    [Range(0.01, double.MaxValue)]
    public decimal PackagePrice { get; set; }
    [Required]
    public string Currency { get; set; } = null!;
    [Range(1, 10)]
    public int TicketCount { get; set; }
}
