namespace TradeStore.Domain.Entities;

public class Location
{
    public Guid Id { get; private set; }
    public string NameLocation { get; private set; } = string.Empty;
    public DateTime DateCreation { get; private set; }
    public DateTime? DateUpdate { get; private set; }
    

    protected Location() {}

    public static Location Create(string nameLocation)
    {
        if(string.IsNullOrWhiteSpace(nameLocation)) throw new ArgumentException("Name is required");

        var location = new Location
        {
            Id = Guid.NewGuid(),
            NameLocation = nameLocation,
            DateCreation = DateTime.UtcNow
        };
        return location;
    }

    public void Update(string nameLocation)
    {
        if(string.IsNullOrWhiteSpace(nameLocation)) throw new ArgumentException("Name ins required");

        if(NameLocation == nameLocation) return;

        NameLocation = nameLocation;
        DateUpdate = DateTime.UtcNow;
    }
}