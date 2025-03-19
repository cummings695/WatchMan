using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Watches.Application.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Watches.Infrastructure.Endpoints.v1;
public static class UpdateWatchEndpoint
{
    internal static RouteHandlerBuilder MapWatchUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateWatchCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateWatchEndpoint))
            .WithSummary("update a Watch")
            .WithDescription("update a Watch")
            .Produces<UpdateWatchResponse>()
            .RequirePermission("Permissions.Watches.Update")
            .MapToApiVersion(1);
    }
}
