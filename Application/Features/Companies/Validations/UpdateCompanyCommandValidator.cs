using Application.Features.Companies.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Validations
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator(ICompanyService companyService)
        {
            RuleFor(command => command.UpdateCompany)
                .SetValidator(new UpdateCompanyRequestValidator(companyService));
        }
    }
}
