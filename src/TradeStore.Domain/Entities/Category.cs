namespace TradeStore.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string NameCategory { get; private set; } = string.Empty;
    
    protected Category(){ }

    public Category(string nameCategory)
    {
        if(string.IsNullOrWhiteSpace(nameCategory)) throw new ArgumentException("Name is required");

        NameCategory = nameCategory;
    }
}