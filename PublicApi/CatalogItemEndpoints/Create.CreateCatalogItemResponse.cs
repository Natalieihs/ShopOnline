using PublicApi;
using PublicApi.CatalogItemEndpoints;
using System;

namespace PublicApi.CatalogItemEndpoints
{
    public class CreateCatalogItemResponse : BaseResponse
    {
        public CreateCatalogItemResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateCatalogItemResponse()
        {
        }

        public CatalogItemDto CatalogItem { get; set; }
    }
}
