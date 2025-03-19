using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Watches.Application.Create.v1;
public sealed record CreateWatchCommand(
    [property: DefaultValue("Sample Product")] string? Name,
    [property: DefaultValue(10)] decimal RetailPrice,
    [property: DefaultValue("Descriptive Description")] string? Description,
    [property: DefaultValue(null)] Guid? BrandId,
    [property: DefaultValue("Make")] string Make,
    [property: DefaultValue("Model")] string Model ,
    [property: DefaultValue("YYY000111")] string ReferenceNumber ,
    [property: DefaultValue("XXX000111")] string? SerialNumber ,
    [property: DefaultValue(0001)]int ProductionYear ,
    [property: DefaultValue("Excelent")]string? Condition ,
    [property: DefaultValue(0)]decimal? WholesalePrice ,
    [property: DefaultValue("/assets/default.png")]string? ValidationImage ,
    [property: DefaultValue(null)]List<string> Images , 
    [property: DefaultValue(false)] bool WatchOnly ,
    [property: DefaultValue(false)]bool HasBox ,
    [property: DefaultValue(false)]bool HasPapers ,
    [property: DefaultValue(false)]bool IsCompleteSet ,
    [property: DefaultValue(0)]int VisibilityScore,
    [property: DefaultValue("Descriptive Description")] string Location
    ) : IRequest<CreateWatchResponse>;
