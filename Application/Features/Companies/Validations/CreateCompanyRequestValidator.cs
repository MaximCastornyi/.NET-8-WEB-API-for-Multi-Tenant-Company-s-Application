using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Validations
{
    internal class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                    .WithMessage("Company name is required.")
                .MaximumLength(60);

            RuleFor(request => request.EstablishedDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                    .WithMessage("Date established cannot be future date.");
        }
    }
}
