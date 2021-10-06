using Microsoft.AspNetCore.Mvc;
using PublicApi;

namespace PublicApi.CatalogItemEndpoints
{
    public class DeleteCatalogItemRequest : BaseRequest 
    {
        //[FromRoute]
        public int CatalogItemId { get; set; }
    }
}
