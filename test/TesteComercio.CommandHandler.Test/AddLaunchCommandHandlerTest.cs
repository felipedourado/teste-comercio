using TesteComercio.Application.Launchs.Command.AddLaunch;
using TesteComercio.Common.Exceptions;
using TesteComercio.Persistence.CommandHandlers.Launchs;
using TesteComercio.Persistence.Db;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TesteComercio.CommandHandler.Test
{
    public class AddLaunchCommandHandlerTest
    {
        [Fact]
        public async Task Should_ThrowException_When_InputIsNull()
        {
            var dbContext = new Mock<CleanArchWriteDbContext>();
            var logger = new Mock<ILogger<AddLaunchCommandHandler>>();

            var commandHandler = new AddLaunchCommandHandler(dbContext.Object, logger.Object);

            var request = new Mock<AddLaunchCommand>();

            //await Assert.ThrowsAsync<InvalidNullInputException>(() => commandHandler.Handle(request.Object, CancellationToken.None));
            await Assert.ThrowsAsync<InvalidNullInputException>(() => commandHandler.Handle(null, CancellationToken.None));
        }
    }
}