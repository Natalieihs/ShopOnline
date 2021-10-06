using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.CatalogItemEndpoints;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace PublicApi.CatalogItemEndpoints
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateCatalogItemRequest>
        .WithResponse<UpdateCatalogItemResponse>
    {
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        private readonly IUriComposer _uriComposer;

        public Update(IAsyncRepository<CatalogItem> itemRepository, IUriComposer uriComposer)
        {
            _itemRepository = itemRepository;
            _uriComposer = uriComposer;
        }

        [HttpPut("api/catalog-items")]
        [SwaggerOperation(
            Summary = "Updates a Catalog Item",
            Description = "Updates a Catalog Item",
            OperationId = "catalog-items.update",
            Tags = new[] { "CatalogItemEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCatalogItemResponse>> HandleAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCatalogItemResponse(request.CorrelationId());

            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

            existingItem.UpdateDetails(request.Name, request.Description, request.Price);
            existingItem.UpdateBrand(request.CatalogBrandId);
            existingItem.UpdateType(request.CatalogTypeId);
            existingItem.UpdateState(request.State);
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
                State=existingItem.State
            };
            response.CatalogItem = dto;
            return response;
        }
    }
}
