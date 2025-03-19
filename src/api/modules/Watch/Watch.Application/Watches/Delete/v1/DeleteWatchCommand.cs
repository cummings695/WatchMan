using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Delete.v1;
public sealed record DeleteWatchCommand(
    Guid Id) : IRequest;
