namespace Presentaion.Models;

public class Invoice
{
    public string Id { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string EventId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; } = null!;
    public string? Status { get; set; }

    public string? IssuerName { get; set; } 
    public string? IssuerAddress { get; set; } 
    public string? IssuerPhoneNumber { get; set; } 
    public string? IssuerEmail { get; set; } 
}
