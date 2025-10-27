using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Validations
{
    internal class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyRequestValidator(ICompanyService companyService)
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .MustAsync(async (id, ct) => await companyService.GetByIdAsync(id) is Company companyInDb && companyInDb.Id == id)
                .WithMessage("Company does not exist.");

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
