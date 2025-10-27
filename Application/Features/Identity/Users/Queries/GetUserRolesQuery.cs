using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Users.Queries
{
    public class GetUserRolesQuery : IRequest<IResponseWrapper>
    {
        public string UserId { get; set; }
    }

    public class GetUserRolesQueryHandler(IUserService userService) : IRequestHandler<GetUserRolesQuery, IResponseWrapper>
    {
        private readonly IUserService _userService = userService;

        public async Task<IResponseWrapper> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _userService.GetUserRolesAsync(request.UserId, cancellationToken);
            return await ResponseWrapper<List<UserRoleResponse>>.SuccessAsync(data: userRoles);
        }
    }
}
