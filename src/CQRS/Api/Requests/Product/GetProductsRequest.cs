namespace Api.Requests.Product
{
    public class GetProductsRequest
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
