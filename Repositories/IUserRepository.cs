using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> LogIn(User val);
        Task UpdateUser(int id, User value);
    }
}