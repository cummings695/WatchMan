using FSH.Starter.WebApi.Watches.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Watches.Application.EventHandlers;

public class WatchCreatedEventHandler(ILogger<WatchCreatedEventHandler> logger) : INotificationHandler<WatchCreated>
{
    public async Task Handle(WatchCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling Watch created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling Watch created domain event..");
    }
}

