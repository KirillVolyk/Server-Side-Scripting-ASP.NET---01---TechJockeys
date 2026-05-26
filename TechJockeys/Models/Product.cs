namespace TechJockeys.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }

        // FK for parent CategoryId (required)
        public int CategoryId { get; set; }

        // Parent object ref. We mark as nullable using ? for reason we'll see later.
        public Category? Category { get; set; }
    }
}
