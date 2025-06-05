using System.ComponentModel.DataAnnotations;

namespace Presentaion.Data.Entities;

public class InvoiceEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string EventId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; } = null!;
    public string? Status { get; set; } 
    public InvoiceIssuerEntity? Issuer { get; set; }
}
