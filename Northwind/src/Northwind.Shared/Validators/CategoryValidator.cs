using FluentValidation;
using Northwind.Shared.Models;

namespace Northwind.Shared.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(o => o.Name).NotEmpty().MinimumLength(5);
    }
}
