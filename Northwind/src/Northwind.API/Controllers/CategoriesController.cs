using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Northwind.Shared.Models;

namespace Northwind.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IValidator<Category> _categoryValidator;

    public CategoriesController(IValidator<Category> categoryValidator)
    {
        _categoryValidator = categoryValidator;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Category category)
    {
        ValidationResult validationResult = _categoryValidator.Validate(category);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(o => o.PropertyName)
                .Select(o => new
                {
                    property = o.Key,
                    messages = o.Select(m => m.ErrorMessage)
                });

            return BadRequest(new { status = false, errors });
        }

        return Created("", new { status = true, data = category });
    }
}
