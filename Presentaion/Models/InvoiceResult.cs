namespace Presentaion.Models;

public class InvoiceResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}
public class InvoiceResult<T> : InvoiceResult
{
    public T? Data { get; set; }
}
