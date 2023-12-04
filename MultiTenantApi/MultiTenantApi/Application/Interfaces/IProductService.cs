using MultiTenantApi.Application.Models;
using MultiTenantApi.Common.Models.Dtos;

namespace MultiTenantApi.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(CreateProductRequestDto createProductRequest);
        bool DeleteProduct(int id);
    }
}
