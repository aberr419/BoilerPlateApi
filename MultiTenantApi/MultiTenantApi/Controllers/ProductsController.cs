using Microsoft.AspNetCore.Mvc;
using MultiTenantApi.Application.Interfaces;
using MultiTenantApi.Common.Models.Dtos;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // TODO request url should be aligned with method names, right now we every request is port/api/Products

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var list = _productService.GetAllProducts();
        return Ok(list);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequestDto request)
    {
        var result = _productService.CreateProduct(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var result = _productService.DeleteProduct(id);
        return Ok(result);
    }

}