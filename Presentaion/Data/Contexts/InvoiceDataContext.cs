using Microsoft.EntityFrameworkCore;
using Presentaion.Data.Entities;

namespace Presentaion.Data.Contexts;

public class InvoiceDataContext(DbContextOptions<InvoiceDataContext> options) : DbContext(options)
{
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<InvoiceIssuerEntity> InvoiceIssuers { get; set; }
}
