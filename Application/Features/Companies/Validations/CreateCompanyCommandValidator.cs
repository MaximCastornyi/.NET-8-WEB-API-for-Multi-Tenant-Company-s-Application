using Application.Features.Companies.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Validations
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(command => command.CreateCompany)
                .SetValidator(new CreateCompanyRequestValidator());
        }
    }
}
