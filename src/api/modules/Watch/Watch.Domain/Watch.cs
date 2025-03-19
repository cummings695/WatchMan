using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Watches.Domain.Events;

namespace FSH.Starter.WebApi.Watches.Domain;
public class Watch : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal RetailPrice { get; private set; }
    
    public string Make { get; private set; }
    
    public string Model { get; private set; }
    
    public string ReferenceNumber { get; private set; }
    
    public string? SerialNumber { get; private set; }
    
    public int ProductionYear { get; private set; }

    public string? Condition { get; private set; }
    
    public decimal? WholesalePrice { get; private set; }
    
    public string? ValidationImage { get; private set; }

    public List<string> Images { get; private set; } = new List<string>();

    public bool WatchOnly { get; private set; }

    public bool HasBox { get; private set; }

    public bool HasPapers { get; private set; }

    public bool IsCompleteSet { get; private set; }

    public int VisibilityScore { get; private set; }
    
    public string? Location { get; private set; }


    private Watch()
    {
       
    }

    private Watch(Guid id, string name, string? description, decimal price, string make, string model, string referenceNumber, string validationImage, string? serialNumber, int productionYear, string? condition, decimal? wholesalePrice, bool watchOnly, bool hasBox, bool hasPapers, bool isCompleteSet, int visibilityScore, string? location)
    {
        Id = id;
        Name = name;
        Description = description;
        RetailPrice = price;
        Make = make;
        Model = model;
        ReferenceNumber = referenceNumber;
        ValidationImage = validationImage;
        SerialNumber = serialNumber;
        ProductionYear = productionYear;
        Condition = condition;
        WholesalePrice = wholesalePrice;
        WatchOnly = watchOnly;
        HasBox = hasBox;
        HasPapers = hasPapers;
        IsCompleteSet = isCompleteSet;
        VisibilityScore = visibilityScore;
        Location = location;

        QueueDomainEvent(new WatchCreated { Watch = this });
    }


    public static Watch Create(string name, string? description, decimal price, string make, string model, string referenceNumber, string validationImage, string? serialNumber, int productionYear, string? condition, decimal? wholesalePrice, bool watchOnly, bool hasBox, bool hasPapers, bool isCompleteSet, int visibilityScore, string? location)
    {
        return new Watch(Guid.NewGuid(), name, description, price, make, model, referenceNumber, validationImage, serialNumber, productionYear, condition, wholesalePrice, watchOnly, hasBox, hasPapers, isCompleteSet, visibilityScore, location);
    }

    public Watch Update(string? name, string? description, decimal? price, string make, string model,
        string referenceNumber, string validationImage, string? serialNumber, int productionYear,
        string? condition, decimal? wholesalePrice, bool watchOnly, bool hasBox, bool hasPapers, bool isCompleteSet,
        int visibilityScore, string? location)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (!string.Equals(Description, description, StringComparison.OrdinalIgnoreCase))
        {
            Description = description;
            isUpdated = true;
        }

        if (price.HasValue && RetailPrice != price.Value)
        {
            RetailPrice = price.Value;
            isUpdated = true;
        }

        if (!string.Equals(Make, make, StringComparison.OrdinalIgnoreCase))
        {
            Make = make;
            isUpdated = true;
        }

        if (!string.Equals(Model, model, StringComparison.OrdinalIgnoreCase))
        {
            Model = model;
            isUpdated = true;
        }

        if (!string.Equals(ReferenceNumber, referenceNumber, StringComparison.OrdinalIgnoreCase))
        {
            ReferenceNumber = referenceNumber;
            isUpdated = true;
        }

        if (!string.Equals(ValidationImage, validationImage, StringComparison.OrdinalIgnoreCase))
        {
            ValidationImage = validationImage;
            isUpdated = true;
        }

        if (!string.Equals(SerialNumber, serialNumber, StringComparison.OrdinalIgnoreCase))
        {
            SerialNumber = serialNumber;
            isUpdated = true;
        }

        if (ProductionYear != productionYear)
        {
            ProductionYear = productionYear;
            isUpdated = true;
        }

        if (!string.Equals(Condition, condition, StringComparison.OrdinalIgnoreCase))
        {
            Condition = condition;
            isUpdated = true;
        }

        if (wholesalePrice.HasValue && WholesalePrice != wholesalePrice.Value)
        {
            WholesalePrice = wholesalePrice.Value;
            isUpdated = true;
        }

        if (WatchOnly != watchOnly)
        {
            WatchOnly = watchOnly;
            isUpdated = true;
        }

        if (HasBox != hasBox)
        {
            HasBox = hasBox;
            isUpdated = true;
        }

        if (HasPapers != hasPapers)
        {
            HasPapers = hasPapers;
            isUpdated = true;
        }

        if (IsCompleteSet != isCompleteSet)
        {
            IsCompleteSet = isCompleteSet;
            isUpdated = true;
        }

        if (VisibilityScore != visibilityScore)
        {
            VisibilityScore = visibilityScore;
            isUpdated = true;
        }

        if (!string.Equals(Location, location, StringComparison.OrdinalIgnoreCase))
        {
            Location = location;
            isUpdated = true;
        }
        
        // Trigger domain event if any property is updated
        if (isUpdated)
        {
            QueueDomainEvent(new WatchUpdated { Watch = this });
        }

        return this;
    }
}

