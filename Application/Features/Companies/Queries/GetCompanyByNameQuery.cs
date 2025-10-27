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
    public class GetCompanyByNameQuery : IRequest<IResponseWrapper>
    {
        public string Name { get; set; }
    }

    public class GetCompanyByNameQueryHandler : IRequestHandler<GetCompanyByNameQuery, IResponseWrapper>
    {
        private readonly ICompanyService _companyService;

        public GetCompanyByNameQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IResponseWrapper> Handle(GetCompanyByNameQuery request, CancellationToken cancellationToken)
        {
            var companyInDb = await _companyService.GetByNameAsync(request.Name);

            if (companyInDb is not null)
            {
                return await ResponseWrapper<CompanyResponse>.SuccessAsync(data: companyInDb.Adapt<CompanyResponse>());
            }
            return await ResponseWrapper<int>.FailAsync("Company does not exist.");
        }
    }
}
