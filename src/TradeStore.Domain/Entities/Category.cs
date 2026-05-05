namespace TradeStore.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string NameCategory { get; private set; } = string.Empty;
    public DateTime DateCreation { get; private set; }
    public DateTime? DateUpdate { get; private set; }
    
    protected Category(){ }

    public static Category Create(string nameCategory)
    {
        if(string.IsNullOrWhiteSpace(nameCategory)) throw new ArgumentException("Name is required");

        var category = new Category
        {
            Id = Guid.NewGuid(),
            NameCategory = nameCategory,
            DateCreation = DateTime.UtcNow
        };
        return category;
    }

    public void Update(string nameCategory)
    {
        if(string.IsNullOrWhiteSpace(nameCategory)) throw new ArgumentException("Name is required");

        if(NameCategory == nameCategory)
            return;

            NameCategory = nameCategory;
            DateUpdate = DateTime.UtcNow;
    }
}