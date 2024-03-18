using FluentValidation;
using FMS.Application.Dto;
using Microsoft.EntityFrameworkCore;

namespace FMS.WebApi.Validations;

public class AddAccountValidator : AbstractValidator<AddAccount>
{
    public AddAccountValidator()
    {
        RuleFor(x => x.AccountName).NotEmpty().NotNull().MaximumLength(50);
        RuleFor(x => x.AccountNumber).NotEmpty().NotNull().MaximumLength(25);
        RuleFor(x => x.AccountType).NotEmpty().NotNull();
    }
}

public class UpdateAccountValidator : AbstractValidator<UpdateAccount>
{
    public UpdateAccountValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.AccountName).NotEmpty().NotNull().MaximumLength(50);
        RuleFor(x => x.AccountNumber).NotEmpty().NotNull().MaximumLength(25);
        RuleFor(x => x.AccountType).NotEmpty().NotNull();
    }
}