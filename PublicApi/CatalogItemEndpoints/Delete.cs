using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace PublicApi.CatalogItemEndpoints
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteCatalogItemRequest>
        .WithResponse<DeleteCatalogItemResponse>
    {
        private readonly IAsyncRepository<CatalogItem> _itemRepository;

        public Delete(IAsyncRepository<CatalogItem> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/catalog-items/{CatalogItemId}")]
        [SwaggerOperation(
            Summary = "Deletes a Catalog Item",
            Description = "Deletes a Catalog Item",
            OperationId = "catalog-items.Delete",
            Tags = new[] { "CatalogItemEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCatalogItemResponse>> HandleAsync([FromRoute] DeleteCatalogItemRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCatalogItemResponse(request.CorrelationId());

            var itemToDelete = await _itemRepository.GetByIdAsync(request.CatalogItemId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}
