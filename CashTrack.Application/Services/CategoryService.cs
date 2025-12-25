using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CashTrack.Application.Services
{
    // Business logic layer for category operations
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repository, ILogger<CategoryService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all categories");
            var categories = await _repository.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} categories", categories.Count);

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving category with ID: {CategoryId}", id);
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
            {
                _logger.LogWarning("Category with ID {CategoryId} not found", id);
                return null;
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createDto)
        {
            _logger.LogInformation("Creating new category: {CategoryName}", createDto.Name);

            var category = new Category
            {
                Name = createDto.Name
            };

            await _repository.CreateAsync(category);
            _logger.LogInformation("Category created with ID: {CategoryId}", category.Id);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDto?> UpdateAsync(int id, CreateCategoryDto updateDto)
        {
            _logger.LogInformation("Updating category with ID: {CategoryId}", id);
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
            {
                _logger.LogWarning("Category with ID {CategoryId} not found for update", id);
                return null;
            }

            category.Name = updateDto.Name;
            await _repository.UpdateAsync(category);
            _logger.LogInformation("Category {CategoryId} updated successfully", id);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting category with ID: {CategoryId}", id);
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
            {
                _logger.LogWarning("Category with ID {CategoryId} not found for deletion", id);
                return false;
            }

            await _repository.DeleteAsync(category);
            _logger.LogInformation("Category {CategoryId} deleted successfully", id);
            return true;
        }
    }
}