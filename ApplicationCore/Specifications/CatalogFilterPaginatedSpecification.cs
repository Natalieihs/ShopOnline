using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base()
        {
            Query
                //.Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
               // (!typeId.HasValue || i.CatalogTypeId == typeId))
                .Skip(skip).Take(take);
        }
    }
}
