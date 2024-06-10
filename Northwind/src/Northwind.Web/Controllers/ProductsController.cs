using Microsoft.AspNetCore.Mvc;
using Northwind.Shared.Models;

namespace Northwind.Web.Controllers;

public class ProductsController : Controller
{
    [HttpGet("products/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("products/create")]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Message"] = "Validation Error";
            return View();
        }

        ViewData["Message"] = "Successful";
        return View();
    }
}
