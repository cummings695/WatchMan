using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Watches.Domain;
using FSH.Starter.WebApi.Watches.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Watches.Application.Update.v1;
public sealed class UpdateWatchHandler(
    ILogger<UpdateWatchHandler> logger,
    [FromKeyedServices("products")] IRepository<Watch> repository)
    : IRequestHandler<UpdateWatchCommand, UpdateWatchResponse>
{
    public async Task<UpdateWatchResponse> Handle(UpdateWatchCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var watch = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = watch ?? throw new WatchNotFoundException(request.Id);
        var updatedProduct = watch.Update(request.Name!, request.Description, request.RetailPrice, 
            request.Make, request.Model, request.ReferenceNumber, request.ValidationImage, request.SerialNumber, 
            request.ProductionYear, request.Condition, request.WholesalePrice, request.WatchOnly, request.HasBox, 
            request.HasPapers, request.IsCompleteSet, request.VisibilityScore, request.Location);
        await repository.UpdateAsync(updatedProduct, cancellationToken);
        logger.LogInformation("watch with id : {Watch} updated.", watch.Id);
        return new UpdateWatchResponse(watch.Id);
    }
}
