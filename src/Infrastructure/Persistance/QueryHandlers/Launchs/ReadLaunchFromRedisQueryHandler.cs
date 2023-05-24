using MediatR;
using Microsoft.EntityFrameworkCore;
using PolyCache.Cache;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteComercio.Application.Launchs.Query.ReadLaunchFromRedis;
using TesteComercio.Domain.Entities.Launchs;
using TesteComercio.Persistence.Db;

namespace TesteComercio.Persistence.QueryHandlers.Products
{
    public class ReadLaunchFromRedisQueryHandler : IRequestHandler<ReadLaunchFromRedisQuery, ReadLaunchFromRedisResponse>
    {
        private readonly CleanArchReadOnlyDbContext _dbContext;
        private readonly IStaticCacheManager _staticCacheManager;

        private const string _cachePrefix = "launch_";
        private const int _cacheExpiryTime = 2; //minitues

        public ReadLaunchFromRedisQueryHandler(CleanArchReadOnlyDbContext dbContext,
                                                IStaticCacheManager staticCacheManager)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _staticCacheManager = staticCacheManager ?? throw new ArgumentNullException(nameof(staticCacheManager));
        }

        public async Task<ReadLaunchFromRedisResponse> Handle(ReadLaunchFromRedisQuery request, CancellationToken cancellationToken)
        {
            var productId = request.LaunchId;

            var result = await _staticCacheManager.GetWithExpireTimeAsync(
                new CacheKey(_cachePrefix + productId),
                _cacheExpiryTime,
                async () => await GetProductAsync());

            return result;

            async Task<ReadLaunchFromRedisResponse> GetProductAsync()
            {
                var product = await _dbContext.Set<Launch>().Where(a => a.Id == productId).Select(a =>
                       new ReadLaunchFromRedisResponse
                       {
                           Name = a.Name,
                           Price = a.Price
                       }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                return product;
            }
        }
    }
}
