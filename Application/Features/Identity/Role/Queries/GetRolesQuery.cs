using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Queries
{
    public class GetRolesQuery : IRequest<IResponseWrapper>
    {
    }

    public class GetRolesQueryHandler(IRoleService roleService) : IRequestHandler<GetRolesQuery, IResponseWrapper>
    {
        private readonly IRoleService _roleService = roleService;

        public async Task<IResponseWrapper> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllAsync(cancellationToken);
            return await ResponseWrapper<List<RoleResponse>>.SuccessAsync(data: roles);
        }
    }
}
