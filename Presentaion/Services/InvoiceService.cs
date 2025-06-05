using Presentaion.Data.Entities;
using Presentaion.Interfaces;
using Presentaion.Models;

namespace Presentaion.Services;

public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

    public async Task<InvoiceResult> CreateInvoiceAsync(InvoiceRequest request)
    {
        decimal fee = 49.99m;

        var invoiceEntity = new InvoiceEntity
        {
            EventId = request.EventId,
            UserId = request.UserId,
            TotalAmount = request.PackagePrice * request.TicketCount + fee,
            Currency = request.Currency,
            Status = "Pending"
        };

        var result = await _invoiceRepository.AddAsync(invoiceEntity);

        return result.Success
            ? new InvoiceResult { Success = true }
            : new InvoiceResult { Success = false, Error = result.Error };
    }

    public async Task<InvoiceResult<Invoice>> GetInvoiceAsync(string id)
    {
        var result = await _invoiceRepository.GetAsync(x => x.Id == id);

        if (result == null || result.Data == null)
            return new InvoiceResult<Invoice> { Success = false, Error = "Invoice not found." };

        var invoice = new Invoice
        {
            Id = result.Data.Id,
            CreatedAt = result.Data.CreatedAt,
            EventId = result.Data.EventId,
            UserId = result.Data.UserId,
            TotalAmount = result.Data.TotalAmount,
            Currency = result.Data.Currency,
            Status = result.Data.Status
        };

        return new InvoiceResult<Invoice> { Success = true, Data = invoice };
    }

    public async Task<InvoiceResult<IEnumerable<Invoice>>> GetAllInvoicesAsync()
    {
        var result = await _invoiceRepository.GetAllAsync();

        if (result == null || result.Data == null)
            return new InvoiceResult<IEnumerable<Invoice>> { Success = false, Error = "No invoices found." };

        var invoices = result.Data.Select(x => new Invoice
        {
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            EventId = x.EventId,
            UserId = x.UserId,
            TotalAmount = x.TotalAmount,
            Currency = x.Currency,
            Status = x.Status
        });

        return new InvoiceResult<IEnumerable<Invoice>> { Success = true, Data = invoices };

    }

    /* Got help with this update method */
    public async Task<InvoiceResult> UpdateInvoiceStatusAsync(string id, string newStatus)
    {
        var existingResult = await _invoiceRepository.GetAsync(x => x.Id == id);

        if (existingResult == null || existingResult.Data == null)
            return new InvoiceResult { Success = false, Error = "Invoice not found." };

        var invoiceEntity = existingResult.Data;
        invoiceEntity.Status = newStatus;

        var updateResult = await _invoiceRepository.UpdateAsync(invoiceEntity);

        return updateResult.Success
            ? new InvoiceResult { Success = true }
            : new InvoiceResult { Success = false, Error = updateResult.Error };
    }
}
