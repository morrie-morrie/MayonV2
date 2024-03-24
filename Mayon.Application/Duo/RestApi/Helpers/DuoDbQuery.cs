using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Mayon.Application.Duo.RestApi.Helpers;
public class DuoDbQuery
{
    private readonly AppDbContext _db;

    public DuoDbQuery(AppDbContext db)
    {
        _db = db;
    }

    public DuoCustomers? GetDuoAccountId(int id)
    {
        var accountId = _db.DuoCustomers
            .AsNoTracking()
            .FirstOrDefault(i => i.Id == id);

        return accountId;
    }
}