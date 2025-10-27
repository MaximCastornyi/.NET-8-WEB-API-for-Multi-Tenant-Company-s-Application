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
    public class GetCompaniesQuery : IRequest<IResponseWrapper>
    {
    }

    public class GetCompanysQueryHandler : IRequestHandler<GetCompaniesQuery, IResponseWrapper>
    {
        private readonly ICompanyService _companyService;

        public GetCompanysQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IResponseWrapper> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companiesInDb = await _companyService.GetAllAsync();

            if (companiesInDb?.Count > 0)
            {
                return await ResponseWrapper<List<CompanyResponse>>
                    .SuccessAsync(data: companiesInDb.Adapt<List<CompanyResponse>>());
            }
            return await ResponseWrapper<int>.FailAsync("No Companies were found.");
        }
    }
}
