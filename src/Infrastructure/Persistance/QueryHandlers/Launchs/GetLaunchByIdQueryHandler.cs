using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteComercio.Application.Launchs.Query.GetLaunchById;
using TesteComercio.Domain.Entities.Launchs;
using TesteComercio.Persistence.Db;

namespace TesteComercio.Persistence.QueryHandlers.Launchs
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetLaunchByIdQuery, LaunchQueryModel>
    {
        private readonly CleanArchReadOnlyDbContext _dbContext;

        public GetProductByIdQueryHandler(CleanArchReadOnlyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<LaunchQueryModel> Handle(GetLaunchByIdQuery request, CancellationToken cancellationToken)
        {
            var existingProduct = await _dbContext.Set<Launch>().Where(a => a.Id == request.LaunchtId).Select(a =>
               new LaunchQueryModel
               {
                   Name = a.Name,
                   Price = a.Price
               }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return existingProduct;
        }
    }
}