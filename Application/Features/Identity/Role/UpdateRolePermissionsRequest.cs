using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role
{
    public class UpdateRolePermissionsRequest
    {
        public string RoleId { get; set; }
        public List<string> NewPermissions { get; set; } = [];
    }
}
