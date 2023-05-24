using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteComercio.Application.Launchs.Query.GetLaunch;
using TesteComercio.Common.Utilities;
using TesteComercio.Domain.Entities.Launchs;
using TesteComercio.Persistence.Db;

namespace TesteComercio.Persistence.QueryHandlers.Products
{
    public class GetLaunchsQueryHandler : IRequestHandler<GetLaunchQuery, PagedResult<Launch>>
    {
        private readonly CleanArchReadOnlyDbContext _dbContext;

        public GetLaunchsQueryHandler(CleanArchReadOnlyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<PagedResult<Launch>> Handle(GetLaunchQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Set<Launch>().GetPaged(request.Page, request.PageSize);

            return products;
        }
    }
}
