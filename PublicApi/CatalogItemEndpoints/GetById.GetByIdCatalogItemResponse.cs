using PublicApi;
using PublicApi.CatalogItemEndpoints;
using System;

namespace PublicApi.CatalogItemEndpoints
{
    public class GetByIdCatalogItemResponse : BaseResponse
    {
        public GetByIdCatalogItemResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdCatalogItemResponse()
        {
        }

        public CatalogItemDto CatalogItem { get; set; }
    }
}
