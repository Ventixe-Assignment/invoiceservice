using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentaion.Interfaces;
using Presentaion.Models;

namespace Presentaion.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{
    private readonly IInvoiceService _invoiceService = invoiceService;

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] InvoiceRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
  
        var result = await _invoiceService.CreateInvoiceAsync(request);
        
        return result.Success
            ? Ok(result)
            : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice(string id)
    {

        var result = await _invoiceService.GetInvoiceAsync(id);

        return result.Success
            ? Ok(result)
            : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var result = await _invoiceService.GetAllInvoicesAsync();

        return result.Success
            ? Ok(result)
            : NotFound(result.Error);
    }

    [HttpPatch("status/{id}")]
    public async Task<IActionResult> UpdateInvoiceStatus(string id, [FromBody] string newStatus)
    {
        if (string.IsNullOrWhiteSpace(newStatus))
            return BadRequest("Status must be provided.");

        var result = await _invoiceService.UpdateInvoiceStatusAsync(id, newStatus);

        return result.Success
            ? Ok()
            : BadRequest(result.Error);
    }
}
