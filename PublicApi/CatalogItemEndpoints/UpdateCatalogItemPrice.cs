using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PublicApi.CatalogItemEndpoints
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UpdateCatalogItemPrice : BaseAsyncEndpoint
        .WithRequest<UpdateCatalogItemPriceRequest>
        .WithResponse<UpdateCatalogItemPriceResponse>

    {
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        private readonly IUriComposer _uriComposer;
        public UpdateCatalogItemPrice(IAsyncRepository<CatalogItem> itemRepository, IUriComposer uriComposer)
        {
            _itemRepository = itemRepository;
            _uriComposer = uriComposer;
        }
        [HttpPut("api/catalog-items/{CatalogItemId}")]
        [SwaggerOperation(
            Summary = "Updates a Catalog Item Price",
            Description = "Updates a Catalog Item Price",
            OperationId = "catalog-items.updatePrice",
            Tags = new[] { "CatalogItemEndpoints" })
        ]
        public async override Task<ActionResult<UpdateCatalogItemPriceResponse>> HandleAsync(UpdateCatalogItemPriceRequest request, CancellationToken cancellationToken = default)
        {
            var response = new UpdateCatalogItemPriceResponse(request.CorrelationId());
            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
            existingItem.UpdatePrice(request.Price);
            await _itemRepository.UpdateAsync(existingItem, cancellationToken);
            var dto = new CatalogItemDto
            {
                Id = existingItem.Id,
                CatalogBrandId = existingItem.CatalogBrandId,
                CatalogTypeId = existingItem.CatalogTypeId,
                Description = existingItem.Description,
                Name = existingItem.Name,
                PictureUri = _uriComposer.ComposePicUri(existingItem.PictureUri),
                Price = existingItem.Price,
                State = existingItem.State
            };
            response.CatalogItem = dto;
            return response;
        }
    }
}
