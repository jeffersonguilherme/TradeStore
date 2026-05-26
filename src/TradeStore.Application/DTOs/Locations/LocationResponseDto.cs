namespace TradeStore.Application.DTOs.Locations;
public class LocationResponseDto
{
    public Guid Id { get; set; }
    public string NameLocation { get; set; } = string.Empty;
    public DateTime DateCreation { get; set; }
    public DateTime? DateUpdate { get; set; } 
}