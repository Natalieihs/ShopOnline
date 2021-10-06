using PublicApi;
using PublicApi.CatalogItemEndpoints;
using System;

namespace PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemResponse : BaseResponse
    {
        public UpdateCatalogItemResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateCatalogItemResponse()
        {
        }

        public CatalogItemDto CatalogItem { get; set; }
    }
}
