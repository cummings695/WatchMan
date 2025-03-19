using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Watches.Application.Get.v1;
using FSH.Starter.WebApi.Watches.Domain;

namespace FSH.Starter.WebApi.Watches.Application.Search.v1;
public class SearchWatchSpecs : EntitiesByPaginationFilterSpec<Watch, WatchResponse>
{
    public SearchWatchSpecs(SearchWatchesCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy());
    // .Where(p => p.BrandId == command.BrandId!.Value, command.BrandId.HasValue);
    // .Where(p => p.Price >= command.MinimumRate!.Value, command.MinimumRate.HasValue)
    // .Where(p => p.Price <= command.MaximumRate!.Value, command.MaximumRate.HasValue);
}
