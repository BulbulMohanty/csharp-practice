namespace Api.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
