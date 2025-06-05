using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presentaion.Data.Entities;

public class InvoiceIssuerEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string IssuerName { get; set; } = "Ventixe and partners";
    public string IssuerAddress { get; set; } = "1234 Pinewood Road, Colorado, USA";
    public string IssuerPhoneNumber { get; set; } = "+1-234-567-8900";
    public string IssuerEmail { get; set; } = "ventixe@paymentsupport.com";


    [ForeignKey(nameof(Invoice))]
    public string InvoiceId { get; set; } = null!;
    public InvoiceEntity? Invoice { get; set; }

}
