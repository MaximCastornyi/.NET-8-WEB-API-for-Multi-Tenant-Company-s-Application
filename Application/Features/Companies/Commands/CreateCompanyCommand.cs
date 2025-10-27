﻿using Application.Pipelines;
using Application.Wrappers;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<IResponseWrapper>, IValidateMe
    {
        public CreateCompanyRequest CreateCompany { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, IResponseWrapper>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IResponseWrapper> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var newCompany = request.CreateCompany.Adapt<Company>();

            var companyId = await _companyService.CreateAsync(newCompany);

            return await ResponseWrapper<int>.SuccessAsync(data: companyId, "Company created successfully.");
        }
    }
}
