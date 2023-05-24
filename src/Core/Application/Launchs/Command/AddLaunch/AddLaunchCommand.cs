using MediatR;

namespace TesteComercio.Application.Launchs.Command.AddLaunch
{
    public class AddLaunchCommand : IRequest<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
