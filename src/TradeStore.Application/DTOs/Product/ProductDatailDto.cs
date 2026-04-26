using TradeStore.Application.DTOs.ValueObjects;

namespace TradeStore.Application.DTOs.Product;

public class ProductDetailDto
{
    public Guid Id { get; set; }
    public string CodTrade { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CodNcm { get; set; } = string.Empty;
    public string CodSap { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public DimensionsDto Dimensions { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public Guid TypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public List<LocationDto> AllowedLocations { get; set; } = new();
    public DateTime DateCreation { get; set; }
    public DateTime DateUpdate { get; set; }
}