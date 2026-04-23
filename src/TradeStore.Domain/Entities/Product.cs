using TradeStore.Domain.ValuesObjects;

namespace TradeStore.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string CodTrade { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string CodNcm { get; private set; } = string.Empty;
    public string CodSap { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public string ImgUrl { get; private set; } = string.Empty;
    public Dimensions Dimensions { get; private set; } = null!;

    public List<Location> AllowedLocations { get; private set; } = new();

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public Guid TypeId { get; private set; }
    public ProductType Type { get; private set; } = null!;
    public DateTime DateCreation { get; private set; }
    public DateTime DateUpdate { get; private set; }

    protected Product(){}

    public Product(string codTrade, 
                    string description, 
                    string codNcm,
                    string codSap,
                    string notes,
                    Dimensions dimensions,
                    string imgUrl,
                    List<Location> allowedLocations,
                    Guid categoryId,
                    Guid typeId
                    )
    {
        if(string.IsNullOrWhiteSpace(codTrade)) throw new ArgumentException("CodTrade is required");
        if(string.IsNullOrEmpty(codNcm)) throw new ArgumentException("CodNcm is required");
        if(dimensions == null) throw new ArgumentException("Dimensions is required");
        if(categoryId == Guid.Empty) throw new ArgumentException("Category is reqquired");
        if(typeId == Guid.Empty) throw new ArgumentException("Type is reqquired");

        Id = Guid.NewGuid();
        CodTrade = codTrade;
        Description = description;
        CodNcm = codNcm;
        CodSap = codSap;
        Notes = notes;
        ImgUrl = imgUrl;
        Dimensions = dimensions;
        CategoryId = categoryId;
        TypeId = typeId;
        AllowedLocations = allowedLocations ?? new();
        DateCreation = DateTime.UtcNow;
        DateUpdate = DateTime.UtcNow;
    }

}