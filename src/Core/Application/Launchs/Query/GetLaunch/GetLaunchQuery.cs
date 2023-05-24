using TesteComercio.Common.Utilities;
using TesteComercio.Domain.Entities.Launchs;
using MediatR;

namespace TesteComercio.Application.Launchs.Query.GetLaunch
{
    public class GetLaunchQuery : IRequest<PagedResult<Launch>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
