using Mayon.Application.Entities.ITGlue.Infra;
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Mayon.Application.ITGlue.Helper;
public class ITGAuth
{
    private readonly AppDbContext _dbContext;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "ITGApiAuthCredentials";
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromHours(1); // Set an appropriate expiration time

    public ITGAuth(AppDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    public async Task<InfraITGApiAuth?> GetITGAuthCredsAsync()
    {
        return await _cache.GetOrCreateAsync(CacheKey, async cacheEntry =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = _cacheExpiration;
            try
            {
                return await _dbContext.ITGApiAuths
                    .OrderBy(i => i.Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error($"Error retrieving ITGlue credentials: {ex.Message}");
                return null;
            }
        });
    }
}