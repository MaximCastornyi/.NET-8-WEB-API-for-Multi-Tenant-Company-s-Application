using Infrastructure.Tenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.OpenApi
{
    public class TenantHeaderAttribute()
        : SwaggerHeaderAttribute(
            headerName: TenancyConstants.TenantIdName,
            description: "Enter your tenant name to access this API.",
            defaultValue: string.Empty,
            isRequired: true)
    {
    }
}
