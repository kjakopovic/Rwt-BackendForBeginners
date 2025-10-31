using BackendForBeginners_Net10_Solution.Dtos;
using BackendForBeginners_Net10_Solution.Models;
using BackendForBeginners_Net10_Solution.Repositories;

namespace BackendForBeginners_Net10_Solution.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> CreateUser(UserDto user)
    {
        var existingUser = await _userRepository.GetByEmail(user.Email);
        if (existingUser is not null)
        {
            throw new Exception("A user with this email already exists.");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            Password = hashedPassword
        };

        await _userRepository.Create(newUser);

        return newUser;
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await _userRepository.GetById(id)
            ?? throw new Exception("User not found");

        await _userRepository.Delete(user);
    }

    public async Task<List<User>> GetUsers(Guid? id)
    {
        if (id is not null)
        {
            var user = await _userRepository.GetById(id.Value)
                ?? throw new Exception("User not found");

            return [user];
        }

        return await _userRepository.GetAll();
    }

    public async Task<User> UpdateUser(UserDto user, Guid id)
    {
        var existingUser = await _userRepository.GetById(id)
            ?? throw new Exception("User not found");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Password = hashedPassword;
        existingUser.UpdatedAt = DateTime.UtcNow;

        await _userRepository.Update(existingUser);

        return existingUser;
    }
}
