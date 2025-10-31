using BackendForBeginners_Net10_Solution.Models;

namespace BackendForBeginners_Net10_Solution.Repositories;

public interface IUserRepository
{
    public Task<User?> GetById(Guid id);

    public Task<User?> GetByEmail(string email);

    public Task<List<User>> GetAll();

    public Task Create(User user);

    public Task Update(User user);

    public Task Delete(User user);
}
