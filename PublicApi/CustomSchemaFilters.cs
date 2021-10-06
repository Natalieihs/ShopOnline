using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicApi
{
    public class CustomSchemaFilters : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var excludeProperties = new[] { "CorrelationId" };

            foreach (var prop in excludeProperties)
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
        }
    }
}
