using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Services
{
    // Service interface for dependency injection
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryWithProductsDto?> GetCategoryWithProductsAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> DeactivateCategoryAsync(int id);
    }

    // Service implementation
    public class CategoryService : ICategoryService
    {
        private readonly ProductCatalogDbContext _context;

        public CategoryService(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ProductCount = c.Products.Count(p => p.IsActive)
                })
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ProductCount = c.Products.Count(p => p.IsActive)
                })
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate,
                ProductCount = category.Products.Count(p => p.IsActive)
            };
        }

        public async Task<CategoryWithProductsDto?> GetCategoryWithProductsAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products.Where(p => p.IsActive))
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return null;

            return new CategoryWithProductsDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate,
                Products = category.Products.Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryName = category.Name,
                    IsActive = p.IsActive
                }).ToList()
            };
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            // Check if category name already exists
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == createCategoryDto.Name.ToLower());

            if (existingCategory != null)
            {
                throw new ArgumentException($"Category with name '{createCategoryDto.Name}' already exists");
            }

            var category = new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return (await GetCategoryByIdAsync(category.Id))!;
        }

        public async Task<CategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            // Check if new name conflicts with existing category
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id != id && c.Name.ToLower() == updateCategoryDto.Name.ToLower());

            if (existingCategory != null)
            {
                throw new ArgumentException($"Category with name '{updateCategoryDto.Name}' already exists");
            }

            // Update category properties
            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;
            category.IsActive = updateCategoryDto.IsActive;

            await _context.SaveChangesAsync();

            return await GetCategoryByIdAsync(id);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return false;

            // Prevent deletion if category has products
            if (category.Products.Any())
            {
                throw new InvalidOperationException("Cannot delete category with associated products. Remove or reassign products first.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            category.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}