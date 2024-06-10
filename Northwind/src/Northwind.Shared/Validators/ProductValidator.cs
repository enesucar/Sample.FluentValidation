using FluentValidation;
using Northwind.Shared.Constants;
using Northwind.Shared.Models;

namespace Northwind.Shared.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(o => o.Name).NotEmpty().WithName("Product Name").WithMessage("Please ensure you have entered your {PropertyName}").MaximumLength(ProductConstants.MaxNameLength);
        RuleFor(o => o.QuantityPerUnit).NotEmpty().MaximumLength(ProductConstants.MaxQuantityPerUnitLength);
        RuleFor(o => o.UnitPrice).GreaterThanOrEqualTo(ProductConstants.UnitPriceGreaterThanOrEqualTo);
        RuleFor(o => o.UnitsInStock).LessThanOrEqualTo(ProductConstants.UnitsInStockLessThanOrEqualTo);
        RuleFor(o => o.Status).IsInEnum();
        RuleFor(o => o.Category).SetValidator(new CategoryValidator());
        //RuleFor(o => o.Category.Name).NotEmpty().When(o => o.Category != null);
        RuleForEach(o => o.Values).NotEmpty();
    }
}
