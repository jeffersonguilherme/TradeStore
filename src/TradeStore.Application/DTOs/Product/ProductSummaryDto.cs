namespace TradeStore.Application.DTOs.Product;

public class ProductSummaryDto
{
    public Guid Id { get; set; }
    public string CodTrade { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CodNcm { get; set; } = string.Empty;
    public string CodSap { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;
}