﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tenancy
{
    public interface ITenantService
    {
        Task<string> CreateTenantAsync(CreateTenantRequest createTenant, CancellationToken ct);
        Task<string> ActivateAsync(string id);
        Task<string> DeactivateAsync(string id);
        Task<string> UpdateSubscriptionAsync(UpdateTenantSubscriptionRequest updateTenantSubscription);
        Task<List<TenantResponse>> GetTenantsAsync();
        Task<TenantResponse> GetTenantByIdAsync(string id);
    }
}
