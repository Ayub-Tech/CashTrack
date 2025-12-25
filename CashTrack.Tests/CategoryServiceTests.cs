using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using CashTrack.Application.Services;
using CashTrack.Domain.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace CashTrack.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _mockRepository;
        private readonly CategoryService _service;

        public CategoryServiceTests()
        {
            _mockRepository = new Mock<ICategoryRepository>();
            _service = new CategoryService(_mockRepository.Object, Mock.Of<ILogger<CategoryService>>());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCategories()
        {
            // Arrange - Set up test data
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" }
            };
            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            // Act - Call the method we're testing
            var result = await _service.GetAllAsync();

            // Assert - Check the results
            result.Should().HaveCount(2);
            result.Should().Contain(c => c.Name == "Food");
            result.Should().Contain(c => c.Name == "Transport");
        }

        [Fact]
        public async Task GetByIdAsync_WhenCategoryExists_ReturnsCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Food" };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(category);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(1);
            result.Name.Should().Be("Food");
        }

        [Fact]
        public async Task GetByIdAsync_WhenCategoryDoesNotExist_ReturnsNull()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Category?)null);

            // Act
            var result = await _service.GetByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_CreatesAndReturnsCategory()
        {
            // Arrange
            var createDto = new CreateCategoryDto { Name = "Shopping" };
            var expectedCategory = new Category { Id = 1, Name = "Shopping" };

            _mockRepository.Setup(r => r.CreateAsync(It.IsAny<Category>()))
                .Callback<Category>(c => c.Id = 1);

            // Act
            var result = await _service.CreateAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Shopping");
            _mockRepository.Verify(r => r.CreateAsync(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WhenCategoryExists_UpdatesAndReturnsCategory()
        {
            // Arrange
            var existingCategory = new Category { Id = 1, Name = "Food" };
            var updateDto = new CreateCategoryDto { Name = "Food & Dining" };

            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);

            // Act
            var result = await _service.UpdateAsync(1, updateDto);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("Food & Dining");
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WhenCategoryDoesNotExist_ReturnsNull()
        {
            // Arrange
            var updateDto = new CreateCategoryDto { Name = "Updated" };
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Category?)null);

            // Act
            var result = await _service.UpdateAsync(999, updateDto);

            // Assert
            result.Should().BeNull();
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Category>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_WhenCategoryExists_DeletesAndReturnsTrue()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Food" };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(category);

            // Act
            var result = await _service.DeleteAsync(1);

            // Assert
            result.Should().BeTrue();
            _mockRepository.Verify(r => r.DeleteAsync(category), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WhenCategoryDoesNotExist_ReturnsFalse()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Category?)null);

            // Act
            var result = await _service.DeleteAsync(999);

            // Assert
            result.Should().BeFalse();
            _mockRepository.Verify(r => r.DeleteAsync(It.IsAny<Category>()), Times.Never);
        }
    }
}