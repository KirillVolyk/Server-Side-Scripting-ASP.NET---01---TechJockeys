namespace TechJockeys.Models
{
    public class Category
    {
        // Properties

        // Using {ModelName}Id as the property tells the server automatically this is a PK(Primary Key)
        public int CategoryId { get; set; }

        public string Name { get; set; }
        

        // child ref to products: 1 category - many products. ref MUST BE nullable with ?
        public List<Product>? Products { get; set; }
    }
}
