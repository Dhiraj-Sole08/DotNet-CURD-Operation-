using AssignmentApp.DBMapper;
using AssignmentApp.DTOs;
using AssignmentApp.Models;
using AssignmentApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApp.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;
        public ProductService(ProductContext productContext)
        {
            _context = productContext;
        }

        public async Task<Product> AddProductAsync(ProductCreateDto dto)
        {
            var category = await _context.ProductCategories.FindAsync(dto.CategoryId);

            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Category = category
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(int id, ProductCreateDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var category = await _context.ProductCategories.FindAsync(dto.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.CategoryId = dto.CategoryId;
            product.Price = dto.Price;

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
