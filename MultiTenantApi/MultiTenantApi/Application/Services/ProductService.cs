using MultiTenantApi.Application.Interfaces;
using MultiTenantApi.Application.Models;
using MultiTenantApi.Common.Base.Contexts;
using MultiTenantApi.Common.Models.Dtos;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context; // database context
    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    // get a list of all products
    public IEnumerable<Product> GetAllProducts()
    {
        IEnumerable<Product> products = _context.Products.ToList();
        return products;
    }

    // get a single product
    public Product GetProductById(int id)
    {
        Product? product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
        return product;
    }

    // create a new product
    public Product CreateProduct(CreateProductRequestDto request)
    {
        Product product = new Product();
        product.Name = request.Name;
        product.Price = request.Price;

        _context.Add(product);
        _context.SaveChanges();

        return product;
    }


    // delete a product
    public bool DeleteProduct(int id)
    {
        Product? product = _context.Products.Where(x => x.Id == id).FirstOrDefault();

        if (product != null)
        {
            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}