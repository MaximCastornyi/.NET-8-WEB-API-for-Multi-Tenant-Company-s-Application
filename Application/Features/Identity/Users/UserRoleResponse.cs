using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Users
{
    public class UserRoleResponse
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }
    }

    public class UserRolesResponse
    {
        public List<UserRoleResponse> UserRoles { get; set; } = [];
    }
}
