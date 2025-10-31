using BackendForBeginners_Net10_Solution.Models;

namespace BackendForBeginners_Net10_Solution.Repositories;

public interface IUserRepository
{
    public User? GetById(Guid id);

    public List<User> GetAll();

    public void Create(User user);

    public void Update(User user);

    public void Delete(User user);
}
