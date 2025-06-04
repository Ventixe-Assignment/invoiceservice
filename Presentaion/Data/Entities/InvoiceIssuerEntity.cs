using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentaion.Data.Entities;

public class InvoiceIssuerEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(Invoice))]
    public string InvoiceId { get; set; } = null!;
    public InvoiceEntity? Invoice { get; set; }

}
