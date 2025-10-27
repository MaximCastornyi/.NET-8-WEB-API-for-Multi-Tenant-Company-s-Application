using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Commands
{
    public class DeleteRoleCommand : IRequest<IResponseWrapper>
    {
        public string RoleId { get; set; }
    }

    public class DeleteRoleCommandHandler(IRoleService roleService) : IRequestHandler<DeleteRoleCommand, IResponseWrapper>
    {
        private readonly IRoleService _roleService = roleService;

        public async Task<IResponseWrapper> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var deletedRole = await _roleService.DeleteAsync(request.RoleId);
            return await ResponseWrapper.SuccessAsync(message: $"Role '{deletedRole}' deleted successfully.");
        }
    }
}
