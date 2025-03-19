using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Get.v1;
public class GetWatchRequest : IRequest<WatchResponse>
{
    public Guid Id { get; set; }
    public GetWatchRequest(Guid id) => Id = id;
}
