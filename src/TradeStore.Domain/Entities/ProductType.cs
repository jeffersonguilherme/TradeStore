namespace TradeStore.Domain.Entities;

public class ProductType
{
    public Guid Id { get; private set; }
    public string NameType { get; private set; } = string.Empty;
    public DateTime DateCreation { get; private set; }
    public DateTime? DateUpdate { get; private set; }

    protected ProductType(){}

    public static ProductType Create(string nameType)
    {
        if(string.IsNullOrWhiteSpace(nameType)) throw new ArgumentException("Name is required");

        var productType = new ProductType
        {
            Id = Guid.NewGuid(),
            NameType = nameType,
            DateCreation = DateTime.UtcNow
        };
        return productType;
    }

    public void Update(string nameType)
    {
        if(string.IsNullOrWhiteSpace(nameType)) throw new ArgumentException("Name is required");
        
        if(NameType == nameType) return;

        NameType = nameType;
        DateUpdate = DateTime.UtcNow;
    }
}