using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Services
{
    // Service interface for dependency injection
    public interface IProductService
    {
        Task<IEnumerable<ProductSummaryDto>> GetAllProductsAsync();
        Task<IEnumerable<ProductSummaryDto>> GetActiveProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductSummaryDto>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductSummaryDto>> SearchProductsAsync(string searchTerm);
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> DeactivateProductAsync(int id);
    }

    // Service implementation
    public class ProductService : IProductService
    {
        private readonly ProductCatalogDbContext _context;

        public ProductService(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name,
                    IsActive = p.IsActive
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetActiveProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive && p.Category.IsActive)
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name,
                    IsActive = p.IsActive
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive,
                CreatedDate = product.CreatedDate,
                LastModifiedDate = product.LastModifiedDate,
                Category = new CategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    Description = product.Category.Description,
                    IsActive = product.Category.IsActive,
                    CreatedDate = product.Category.CreatedDate,
                    ProductCount = 0
                }
            };
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId && p.IsActive && p.Category.IsActive)
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name,
                    IsActive = p.IsActive
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductSummaryDto>> SearchProductsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetActiveProductsAsync();

            var lowerSearchTerm = searchTerm.ToLower();

            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive && p.Category.IsActive &&
                           (p.Name.ToLower().Contains(lowerSearchTerm) ||
                            p.Description!.ToLower().Contains(lowerSearchTerm) ||
                            p.Category.Name.ToLower().Contains(lowerSearchTerm)))
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name,
                    IsActive = p.IsActive
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            // Verify the category exists and is active
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == createProductDto.CategoryId && c.IsActive);

            if (category == null)
            {
                throw new ArgumentException($"Category with ID {createProductDto.CategoryId} not found or inactive");
            }

            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                StockQuantity = createProductDto.StockQuantity,
                CategoryId = createProductDto.CategoryId,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return (await GetProductByIdAsync(product.Id))!;
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;

            // Verify the category exists and is active if it's being changed
            if (product.CategoryId != updateProductDto.CategoryId)
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == updateProductDto.CategoryId && c.IsActive);

                if (category == null)
                {
                    throw new ArgumentException($"Category with ID {updateProductDto.CategoryId} not found or inactive");
                }
            }

            // Update the product properties
            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;
            product.CategoryId = updateProductDto.CategoryId;
            product.IsActive = updateProductDto.IsActive;
            product.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            product.IsActive = false;
            product.LastModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}