namespace TradeStore.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string CodTrade { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string CodNcm { get; private set; } = string.Empty;
    public string CodSap { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public Dimensions Dimensions { get; private set; } = null!;
    public string ImgUrl { get; private set; } = string.Empty;
    public List<Location> AllowedLocations { get; private set; } = new();
    public Category Category { get; private set; } = null!;
    public ProductType Type { get; private set; } = null!;
    public DateTime DataCreation { get; private set; }
    public DateTime DataUpdate { get; private set; }

}