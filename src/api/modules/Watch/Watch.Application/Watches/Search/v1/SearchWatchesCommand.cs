using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Watches.Application.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Search.v1;

public class SearchWatchesCommand : PaginationFilter, IRequest<PagedList<WatchResponse>>
{
    public Guid? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}
