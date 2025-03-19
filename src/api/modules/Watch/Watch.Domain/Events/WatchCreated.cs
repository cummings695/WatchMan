using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Watches.Domain.Events;
public sealed record WatchCreated : DomainEvent
{
    public Watch? Watch { get; set; }
}
