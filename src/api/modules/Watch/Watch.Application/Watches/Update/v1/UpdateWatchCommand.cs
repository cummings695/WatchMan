using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Update.v1;
public sealed record UpdateWatchCommand(
    Guid Id,
    string? Name,
    decimal RetailPrice,
    string? Description,
    string Make,
    string Model ,
    string ReferenceNumber ,
    string? SerialNumber ,
    int ProductionYear ,
    string? Condition ,
    decimal? WholesalePrice ,
    string? ValidationImage ,
    List<string> Images , 
    bool WatchOnly ,
    bool HasBox ,
    bool HasPapers ,
    bool IsCompleteSet ,
    int VisibilityScore,
    string Location) : IRequest<UpdateWatchResponse>;
