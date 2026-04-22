namespace TradeStore.Domain.Entities;

public class Location
{
    public Guid Id { get; private set; }
    public string NameLocation { get; private set; } = string.Empty;

    protected Location() {}

    public Location(string nameLocation)
    {
        if(string.IsNullOrWhiteSpace(nameLocation)) throw new ArgumentException("Name is required");

        NameLocation = nameLocation;
    }
}