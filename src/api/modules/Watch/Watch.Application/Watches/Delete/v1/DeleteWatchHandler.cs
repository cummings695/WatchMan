using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Watches.Domain;
using FSH.Starter.WebApi.Watches.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Watches.Application.Delete.v1;
public sealed class DeleteWatchHandler(
    ILogger<DeleteWatchHandler> logger,
    [FromKeyedServices("products")] IRepository<Watch> repository)
    : IRequestHandler<DeleteWatchCommand>
{
    public async Task Handle(DeleteWatchCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = product ?? throw new WatchNotFoundException(request.Id);
        await repository.DeleteAsync(product, cancellationToken);
        logger.LogInformation("product with id : {ProductId} deleted", product.Id);
    }
}
