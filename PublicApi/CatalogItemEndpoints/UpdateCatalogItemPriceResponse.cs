using System;

namespace PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemPriceResponse:BaseResponse
    {
        public UpdateCatalogItemPriceResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateCatalogItemPriceResponse()
        {
        }

        public CatalogItemDto CatalogItem { get; set; }
    }
}