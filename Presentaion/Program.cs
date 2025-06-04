var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();













var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
