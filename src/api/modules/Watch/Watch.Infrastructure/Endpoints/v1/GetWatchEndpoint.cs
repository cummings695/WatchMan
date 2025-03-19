using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Watches.Application.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Watches.Infrastructure.Endpoints.v1;
public static class GetWatchEndpoint
{
    internal static RouteHandlerBuilder MapGetWatchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetWatchRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetWatchEndpoint))
            .WithSummary("gets Watch by id")
            .WithDescription("gets Watch by id")
            .Produces<WatchResponse>()
            .RequirePermission("Permissions.Watches.View")
            .MapToApiVersion(1);
    }
}
