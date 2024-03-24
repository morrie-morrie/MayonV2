using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Services;

namespace Mayon.Application.Microsoft.Graph.Helper;
public class MSGraphHelper
{
    public static AdminMsApiAuth? GetMSAuthCreds()
    {
        using var db = new AppDbContext();
        var query = db.adminMsApiAuths
            .OrderBy(i => i.Id)
            .First();
        return query;
    }
}