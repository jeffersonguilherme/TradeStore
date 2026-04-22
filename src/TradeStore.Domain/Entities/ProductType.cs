namespace TradeStore.Domain.Entities;

public class ProductType
{
    public Guid Id { get; private set; }
    public string NameType { get; private set; } = string.Empty;

    protected ProductType(){}

    public ProductType(string nameType)
    {
        if(string.IsNullOrWhiteSpace(nameType)) throw new ArgumentException("Name is required");

        NameType = nameType;
    }
}