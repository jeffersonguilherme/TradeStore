namespace TradeStore.Application.DTOs.ProductTypes;

public class ProductTypeResponseDto
{
    public Guid Id { get; set; }
    public string NameType { get; set; } = string.Empty;
    public DateTime DateCreation { get; set; }
    public DateTime? DateUpdate { get; set; }
}