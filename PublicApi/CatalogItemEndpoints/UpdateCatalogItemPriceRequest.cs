namespace PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemPriceRequest:BaseRequest
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
    }
}