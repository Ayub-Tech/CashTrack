using CashTrack.Application.DTOs;

namespace CashTrack.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto createDto);
        Task<CategoryDto?> UpdateAsync(int id, CreateCategoryDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}