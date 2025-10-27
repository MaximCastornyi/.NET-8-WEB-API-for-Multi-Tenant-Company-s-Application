using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Queries
{
    public class GetRoleWithPermissionsQuery : IRequest<IResponseWrapper>
    {
        public string RoleId { get; set; }
    }

    public class GetRoleWithPermissionsQueryHandler(IRoleService roleService) : IRequestHandler<GetRoleWithPermissionsQuery, IResponseWrapper>
    {
        private readonly IRoleService _roleService = roleService;

        public async Task<IResponseWrapper> Handle(GetRoleWithPermissionsQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetRoleWithPermissionsAsync(request.RoleId, cancellationToken);
            return await ResponseWrapper<RoleResponse>.SuccessAsync(data: role);
        }
    }
}
