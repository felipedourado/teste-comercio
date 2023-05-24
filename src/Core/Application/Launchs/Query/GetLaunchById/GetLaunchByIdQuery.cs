using MediatR;

namespace TesteComercio.Application.Launchs.Query.GetLaunchById
{
    public class GetLaunchByIdQuery : IRequest<LaunchQueryModel>
    {
        public int LaunchtId { get; set; }
    }
}