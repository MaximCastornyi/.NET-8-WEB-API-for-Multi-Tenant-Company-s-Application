using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tenancy
{
    public class TenantDbContext(DbContextOptions<TenantDbContext> options)
        : EFCoreStoreDbContext<ABCCompanyTenantInfo>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ABCCompanyTenantInfo>()
                .ToTable("Tenants", "Multitenancy");
        }
    }
}
