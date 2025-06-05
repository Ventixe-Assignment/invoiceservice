using Microsoft.EntityFrameworkCore;
using Presentaion.Data.Contexts;
using Presentaion.Data.Entities;
using Presentaion.Interfaces;
using Presentaion.Models;
using System.Linq.Expressions;

namespace Presentaion.Data.Repositories;
public class InvoiceRepository(InvoiceDataContext context) : BaseRepository<InvoiceEntity>(context), IInvoiceRepository
{
    public async override Task<RepoResult<IEnumerable<InvoiceEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table
                .Include(x => x.Issuer)
                .ToListAsync();
            return new RepoResult<IEnumerable<InvoiceEntity>> { Success = true, Data = entities };
        }
        catch (Exception ex)
        {
            return new RepoResult<IEnumerable<InvoiceEntity>> { Success = false, Error = ex.Message };
        }
    }

    public async override Task<RepoResult<InvoiceEntity>> GetAsync(Expression<Func<InvoiceEntity, bool>> expression)
    {
        try
        {
            var entity = await _table
                .Include(x => x.Issuer)
                .FirstOrDefaultAsync(expression) ?? throw new Exception("Entity not found");
            return new RepoResult<InvoiceEntity> { Success = true, Data = entity };
        }
        catch (Exception ex)
        {
            return new RepoResult<InvoiceEntity> { Success = false, Error = ex.Message };
        }
    }
}
