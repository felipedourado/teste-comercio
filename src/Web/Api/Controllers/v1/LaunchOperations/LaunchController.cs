using TesteComercio.Api.Controllers.v1.Launchs.Requests;
using TesteComercio.ApiFramework.Tools;
using TesteComercio.Application.Launchs.Command.AddLaunch;
using TesteComercio.Application.Launchs.Query.GetLaunchById;
using TesteComercio.Application.Launchs.Query.GetLaunch;
using TesteComercio.Application.Launchs.Query.ReadLaunchFromRedis;
using TesteComercio.Common.Utilities;
using TesteComercio.Domain.Entities.Launchs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TesteComercio.Api.Controllers.v1.Products
{
    [ApiVersion("1")]
    public class LaunchController : BaseControllerV1
    {
        /// <summary>
        /// saves launch
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionContext), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ExceptionContext), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] AddLaunchRequest request)
        {
            var command = request.Adapt<AddLaunchCommand>();

            var result = await Mediator.Send(command);

            return new ApiResult<int>(result);
        }

        [HttpGet]
        [SwaggerOperation("get launch by id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int launchId)
        {
            var result = await Mediator.Send(new GetLaunchByIdQuery { LaunchtId = launchId });
            return new ApiResult<LaunchQueryModel>(result);
        }

        [HttpGet("all")]
        [SwaggerOperation("get all launch operations")]
        public async Task<IActionResult> GetAllAsync(GetLaunchRequest request)
        {
            var query = request.Adapt<GetLaunchQuery>();

            var result = await Mediator.Send(query);
            return new ApiResult<PagedResult<Launch>>(result);
        }

        [HttpGet("cache-redis")]
        [SwaggerOperation("get a launch from cache. this is a example for how to use cache")]
        public async Task<IActionResult> ReadFromCacheAsync([FromQuery] int launchId)
        {
            var result = await Mediator.Send(new ReadLaunchFromRedisQuery(launchId));
            return new ApiResult<ReadLaunchFromRedisResponse>(result);
        }
    }
}