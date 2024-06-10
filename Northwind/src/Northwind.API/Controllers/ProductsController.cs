using Microsoft.AspNetCore.Mvc;
using Northwind.Shared.Models;

namespace Northwind.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .Select(o => new
                {
                    property = o.Key,
                    messages = o.Value?.Errors.Select(o => o.ErrorMessage)
                });

            return BadRequest(new { status = false, errors });
        }

        return Created("", new { status = true, data = product });
    }
}
