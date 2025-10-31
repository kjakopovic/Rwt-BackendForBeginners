using BackendForBeginners_Net10_Solution.Dtos;
using BackendForBeginners_Net10_Solution.Models;

namespace BackendForBeginners_Net10_Solution.Services;

public interface IUserService
{
    public Task<List<User>> GetUsers(Guid? id);

    public Task<User> CreateUser(UserDto user);

    public Task<User> UpdateUser(UserDto user, Guid id);

    public Task DeleteUser(Guid id);
}
