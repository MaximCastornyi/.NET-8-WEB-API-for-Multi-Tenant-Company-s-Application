using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Commands
{
    public class UpdateRoleCommand : IRequest<IResponseWrapper>
    {
        public UpdateRoleRequest UpdateRole { get; set; }
    }

    public class UpdateRoleCommandHandler(IRoleService roleService) : IRequestHandler<UpdateRoleCommand, IResponseWrapper>
    {
        private readonly IRoleService _roleService = roleService;

        public async Task<IResponseWrapper> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var updatedRole = await _roleService.UpdateAsync(request.UpdateRole);
            return await ResponseWrapper.SuccessAsync(message: $"Role '{updatedRole}' updated successfully.");
        }
    }
}
