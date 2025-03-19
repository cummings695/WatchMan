using Ardalis.Specification;
using FSH.Starter.WebApi.Watches.Domain;

namespace FSH.Starter.WebApi.Watches.Application.Get.v1;

public class GetWatchSpecs : Specification<Watch, WatchResponse>
{
    public GetWatchSpecs(Guid id)
    {
        Query
            .Where(p => p.Id == id);
    }
}
