namespace TradeStore.Domain.Entities;

public class Dimensions
{
    public decimal Length { get; private set; }
    public decimal Width { get; private set; }
    public decimal Height { get; private set; }

    public Dimensions(decimal length, decimal width, decimal height)
    {
        if(length <= 0 || width <= 0 || height <= 0)
            throw new ArgumentException("All demensions must be greater than zero.");

        Length = length;
        Width = width;
        Height = height;
    }
}