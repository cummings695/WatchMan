using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Watches.Application.Get.v1;
using FSH.Starter.WebApi.Watches.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FSH.Starter.WebApi.Watches.Application.Search.v1;
public sealed class SearchWatchHandler(
    [FromKeyedServices("products")] IReadRepository<Watch> repository)
    : IRequestHandler<SearchWatchesCommand, PagedList<WatchResponse>>
{
    public async Task<PagedList<WatchResponse>> Handle(SearchWatchesCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchWatchSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<WatchResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}

