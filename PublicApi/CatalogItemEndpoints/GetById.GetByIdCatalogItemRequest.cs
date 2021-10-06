using PublicApi;

namespace PublicApi.CatalogItemEndpoints
{
    public class GetByIdCatalogItemRequest : BaseRequest 
    {
        public int CatalogItemId { get; set; }
    }
}
