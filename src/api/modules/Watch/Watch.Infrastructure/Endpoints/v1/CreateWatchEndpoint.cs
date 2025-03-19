using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Watches.Application.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Watches.Infrastructure.Endpoints.v1;
public static class CreateWatchEndpoint
{
    internal static RouteHandlerBuilder MapWatchCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateWatchCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateWatchEndpoint))
            .WithSummary("creates a product")
            .WithDescription("creates a product")
            .Produces<CreateWatchResponse>()
            .RequirePermission("Permissions.Products.Create")
            .MapToApiVersion(1);
    }
}
