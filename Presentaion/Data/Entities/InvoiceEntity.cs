using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Presentaion.Data.Entities;

public class InvoiceEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string EventId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public ICollection<InvoiceIssuerEntity> Issuers { get; set; } = [];
}
