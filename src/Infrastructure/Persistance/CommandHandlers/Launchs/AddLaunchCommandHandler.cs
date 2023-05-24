using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteComercio.Application.Launchs.Command.AddLaunch;
using TesteComercio.Common.Exceptions;
using TesteComercio.Domain.Entities.Launchs;
using TesteComercio.Persistence.Db;

namespace TesteComercio.Persistence.CommandHandlers.Launchs
{
    public class AddLaunchCommandHandler : IRequestHandler<AddLaunchCommand, int>
    {
        private readonly CleanArchWriteDbContext _dbContext;
        private readonly ILogger<AddLaunchCommandHandler> _logger;

        public AddLaunchCommandHandler(CleanArchWriteDbContext dbContext, ILogger<AddLaunchCommandHandler> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddLaunchCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new InvalidNullInputException(nameof(request));

            var product = new Launch
            {
                Name = request.Name,
                Price = request.Price
            };

            await _dbContext.Set<Launch>().AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Launch Inserted", product);

            return product.Id;
        }
    }
}
