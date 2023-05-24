using MediatR;

namespace TesteComercio.Application.Launchs.Query.ReadLaunchFromRedis
{
    public class ReadLaunchFromRedisQuery : IRequest<ReadLaunchFromRedisResponse>
    {
        public ReadLaunchFromRedisQuery(int launchId)
        {
            LaunchId = launchId;
        }

        public int LaunchId { get; private set; }
    }
}
