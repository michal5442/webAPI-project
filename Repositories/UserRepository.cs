using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;
namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        UserContext _userContext;
       public UserRepository(UserContext userContext) 
        {
            _userContext=userContext;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
           await _userContext.Users.AddAsync(user);
           await _userContext.SaveChangesAsync();
           return user;
        }

        public async Task<User> LogIn(User val)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x=>x.UserName == val.UserName && x.Password == val.Password);
            return user;
        }

        public async Task UpdateUser(int id, User value)
        {
            _userContext.Users.Update(value);
            await _userContext.SaveChangesAsync();
        }
    }
}
