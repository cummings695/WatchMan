using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.Watches.Domain;
using FSH.Starter.WebApi.Watches.Infrastructure.Endpoints.v1;
using FSH.Starter.WebApi.Watches.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Watches.Infrastructure;
public static class WatchModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("watches") { }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var productGroup = app.MapGroup("products").WithTags("products");
            productGroup.MapWatchCreationEndpoint();
            productGroup.MapGetWatchEndpoint();
            productGroup.MapGetWatchListEndpoint();
            productGroup.MapWatchUpdateEndpoint();
            productGroup.MapWatchDeleteEndpoint();

            // var brandGroup = app.MapGroup("brands").WithTags("brands");
            // brandGroup.MapBrandCreationEndpoint();
            // brandGroup.MapGetBrandEndpoint();
            // brandGroup.MapGetBrandListEndpoint();
            // brandGroup.MapBrandUpdateEndpoint();
            // brandGroup.MapBrandDeleteEndpoint();
        }
    }
    public static WebApplicationBuilder RegisterWatchServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<WatchDbContext>();
        builder.Services.AddScoped<IDbInitializer, WatchDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<Watch>, WatchRepository<Watch>>("watches");
        builder.Services.AddKeyedScoped<IReadRepository<Watch>, WatchRepository<Watch>>("watches");
        return builder;
    }
    public static WebApplication UseWatchModule(this WebApplication app)
    {
        return app;
    }
}
