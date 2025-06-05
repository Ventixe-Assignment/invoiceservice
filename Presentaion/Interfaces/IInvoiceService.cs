using Presentaion.Models;

namespace Presentaion.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceResult> CreateInvoiceAsync(InvoiceRequest request);
        Task<InvoiceResult<IEnumerable<Invoice>>> GetAllInvoicesAsync();
        Task<InvoiceResult<Invoice>> GetInvoiceAsync(string id);
        Task<InvoiceResult> UpdateInvoiceStatusAsync(string id, string newStatus);
    }
}