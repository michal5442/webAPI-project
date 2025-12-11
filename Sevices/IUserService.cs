using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> LogIn(User user);
        Task<bool> UpdateUser(User user, int id);
    }
}