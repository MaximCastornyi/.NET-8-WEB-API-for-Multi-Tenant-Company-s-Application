﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Queries
{
    public class GetRoleByIdQuery : IRequest<IResponseWrapper>
    {
        public string RoleId { get; set; }
    }

    public class GetRoleByIdQueryHandler(IRoleService roleService) : IRequestHandler<GetRoleByIdQuery, IResponseWrapper>
    {
        private readonly IRoleService _roleService = roleService;

        public async Task<IResponseWrapper> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetByIdAsync(request.RoleId, cancellationToken);
            return await ResponseWrapper<RoleResponse>.SuccessAsync(data: role);
        }
    }
}
