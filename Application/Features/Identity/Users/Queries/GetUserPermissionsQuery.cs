﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Users.Queries
{
    public class GetUserPermissionsQuery : IRequest<IResponseWrapper>
    {
        public string UserId { get; set; }
    }

    public class GetUserPermissionsQueryHanlder(IUserService userService)
        : IRequestHandler<GetUserPermissionsQuery, IResponseWrapper>
    {
        private readonly IUserService _userService = userService;

        public async Task<IResponseWrapper> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _userService.GetUserPermissionsAsync(request.UserId, cancellationToken);
            return await ResponseWrapper<List<string>>.SuccessAsync(data: permissions);
        }
    }
}
