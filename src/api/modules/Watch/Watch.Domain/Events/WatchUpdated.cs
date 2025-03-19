using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Watches.Domain.Events;
public sealed record WatchUpdated : DomainEvent
{
    public Watch? Watch { get; set; }
}
