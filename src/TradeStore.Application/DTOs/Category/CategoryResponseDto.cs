namespace TradeStore.Application.DTOs.Category;

public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public string NameCategory { get; set; } = string.Empty;
    public DateTime DateCreation { get; set; }
    public DateTime? DateUpdate { get; set; }
}