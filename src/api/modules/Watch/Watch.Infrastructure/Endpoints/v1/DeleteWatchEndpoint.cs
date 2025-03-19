using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Watches.Application.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Watches.Infrastructure.Endpoints.v1;
public static class DeleteWatchEndpoint
{
    internal static RouteHandlerBuilder MapWatchDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteWatchCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteWatchEndpoint))
            .WithSummary("deletes Watch by id")
            .WithDescription("deletes Watch by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Watches.Delete")
            .MapToApiVersion(1);
    }
}
