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

    public string IssuerName { get; set; } = "Ventixe and partners";
    public string IssuerAddress { get; set; } = "1234 Pinewood Road, Colorado, USA";
    public string IssuerPhoneNumber { get; set; } = "+1-234-567-8900";
    public string IssuerEmail { get; set; } = "ventixe@paymentsupport.com";
}
