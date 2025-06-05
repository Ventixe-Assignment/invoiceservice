using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Data.Contexts;

public class InvoiceDataContextFactory : IDesignTimeDbContextFactory<InvoiceDataContext>
{
    public InvoiceDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InvoiceDataContext>();

        var connectionString = Environment.GetEnvironmentVariable("SqlConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new InvoiceDataContext(optionsBuilder.Options);
    }


}
