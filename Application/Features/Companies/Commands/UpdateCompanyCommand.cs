﻿using Application.Pipelines;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest<IResponseWrapper>, IValidateMe
    {
        public UpdateCompanyRequest UpdateCompany { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IResponseWrapper>
    {
        private readonly ICompanyService _companyService;

        public UpdateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IResponseWrapper> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyInDb = await _companyService.GetByIdAsync(request.UpdateCompany.Id);

            if (companyInDb is not null)
            {
                companyInDb.Name = request.UpdateCompany.Name;
                companyInDb.EstablishedDate = request.UpdateCompany.EstablishedDate;

                var updatedCompanyId = await _companyService.UpdateAsync(companyInDb);

                return await ResponseWrapper<int>.SuccessAsync(data: updatedCompanyId, "Company updated successfully.");
            }
            return await ResponseWrapper<int>.FailAsync("Company does not exist.");
        }
    }
}
