using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Watches.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Watches.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Get.v1;
public sealed class GetWatchHandler(
    [FromKeyedServices("products")] IReadRepository<Watch> repository,
    ICacheService cache)
    : IRequestHandler<GetWatchRequest, WatchResponse>
{
    public async Task<WatchResponse> Handle(GetWatchRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"product:{request.Id}",
            async () =>
            {
                var spec = new GetWatchSpecs(request.Id);
                var productItem = await repository.FirstOrDefaultAsync(spec, cancellationToken);
                if (productItem == null) throw new WatchNotFoundException(request.Id);
                return productItem;
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
