using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using CashTrack.Domain.Entities;

namespace CashTrack.Application.Services
{
    // Business logic for user operations
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto createDto)
        {
            var user = new User
            {
                Name = createDto.Name,
                Email = createDto.Email
            };

            await _repository.CreateAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<UserDto?> UpdateAsync(int id, CreateUserDto updateDto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return null;

            user.Name = updateDto.Name;
            user.Email = updateDto.Email;

            await _repository.UpdateAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return false;

            await _repository.DeleteAsync(user);
            return true;
        }
    }
}