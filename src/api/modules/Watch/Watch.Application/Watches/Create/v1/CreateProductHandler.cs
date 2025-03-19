using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Watches.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Watches.Application.Create.v1;
public sealed class CreateProductHandler(
    ILogger<CreateProductHandler> logger,
    [FromKeyedServices("watches")] IRepository<Domain.Watch> repository)
    : IRequestHandler<CreateWatchCommand, CreateWatchResponse>
{
    public async Task<CreateWatchResponse> Handle(CreateWatchCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var product = Watch.Create(request.Name!, request.Description, request.RetailPrice,  
            request.Make, request.Model, request.ReferenceNumber, request.ValidationImage, request.SerialNumber, 
            request.ProductionYear, request.Condition, request.WholesalePrice, request.WatchOnly, request.HasBox, 
            request.HasPapers, request.IsCompleteSet, request.VisibilityScore, request.Location);
        await repository.AddAsync(product, cancellationToken);
        logger.LogInformation("product created {ProductId}", product.Id);
        return new CreateWatchResponse(product.Id);
    }
}
