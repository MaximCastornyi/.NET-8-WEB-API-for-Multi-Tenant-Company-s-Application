using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tenancy
{
    public class TenancyConstants
    {
        public const string TenantIdName = "tenant";
        public const string DefaultPassword = "123456789";
        public const string FirstName = "Maxim";
        public const string LastName = "Dragon";

        public static class Root
        {
            public const string Id = "root";
            public const string Name = "Root";
            public const string Email = "max@max.com";
        }
    }
}
