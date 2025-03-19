using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Watches.Domain.Exceptions;
public sealed class WatchNotFoundException : NotFoundException
{
    public WatchNotFoundException(Guid id)
        : base($"Watch with id {id} not found")
    {
    }
}
