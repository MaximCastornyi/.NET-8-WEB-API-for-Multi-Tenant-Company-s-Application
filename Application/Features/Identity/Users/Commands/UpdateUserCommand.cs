using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Users.Commands
{
    public class UpdateUserCommand : IRequest<IResponseWrapper>
    {
        public UpdateUserRequest UpdateUser { get; set; }
    }

    public class UpdateUserCommandHanlder(IUserService userService) : IRequestHandler<UpdateUserCommand, IResponseWrapper>
    {
        private readonly IUserService _userService = userService;

        public async Task<IResponseWrapper> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userService.UpdateAsync(request.UpdateUser);
            return await ResponseWrapper<string>.SuccessAsync(data: userId, message: "User updated successfully.");
        }
    }
}
