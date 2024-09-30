using AssignmentApp.DTOs;
using AssignmentApp.Models;

namespace AssignmentApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> AddProductAsync(ProductCreateDto dto);
        Task<Product> UpdateProductAsync(int id, ProductCreateDto dto);
        Task DeleteProductAsync(int id);
    }
}
