using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constants
{
    public static class RoleConstants
    {
        public const string Admin = nameof(Admin);
        public const string Basic = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(
        [
            Admin,
            Basic
        ]);

        public static bool IsDefaultRole(string roleName) => DefaultRoles.Contains(roleName);
    }
}
