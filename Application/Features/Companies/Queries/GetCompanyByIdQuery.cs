using Application.Wrappers;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries
{
    public class GetCompanyByIdQuery : IRequest<IResponseWrapper>
    {
        public int CompanyId { get; set; }
    }

    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, IResponseWrapper>
    {
        private readonly ICompanyService _companyService;
        public async Task<IResponseWrapper> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var companyInDb = await _companyService.GetByIdAsync(request.CompanyId);

            if (companyInDb is not null)
            {
                return await ResponseWrapper<CompanyResponse>.SuccessAsync(data: companyInDb.Adapt<CompanyResponse>());
            }
            return await ResponseWrapper<int>.FailAsync("Company does not exist.");
        }
    }
}
