
namespace FSH.Starter.WebApi.Watches.Application.Get.v1;
public sealed record WatchResponse(Guid? Id, string Name, string? Description, decimal Price);
