using Microsoft.EntityFrameworkCore;
using Presentaion.Data.Contexts;
using Presentaion.Data.Repositories;
using Presentaion.Interfaces;
using Presentaion.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<InvoiceDataContext>(opt => opt.UseSqlServer(builder.Configuration["SqlConnection"]));
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();





var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
