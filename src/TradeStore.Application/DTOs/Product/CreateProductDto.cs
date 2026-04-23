using TradeStore.Domain.ValueObjects;

namespace TradeStore.Application.DTOs.Product;

public class CreateProductDto
{
    public string CodTrade { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CodNcm { get; set; } = string.Empty;
    public string CodSap { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public DimensionsDto Dimensions { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Guid TypeId { get; set; }
    public List<Guid> AllowedLocations { get; set; } = new();

}