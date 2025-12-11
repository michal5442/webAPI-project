using Entities;
using Repositories;

namespace Services;

public class UserService : IUserService
    {

        IUserRepository repository;
        IPasswordService service;

        public UserService(IUserRepository repository, IPasswordService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<User> GetUserById(int id) 
        { 
            return await repository.GetUserById(id);
        }

        public async Task<User> AddUser(User user)
        { 
            if(service.Check(user.Password).Strength<2)
            {
                return null;
            }
            else
            {
            return await repository.AddUser(user);
            }        
        }

        public async Task<bool> UpdateUser(User user, int id)
        {
        if (service.Check(user.Password).Strength < 2)
            {
                return false;
            }
            await repository.UpdateUser(id,user);
            return true;
        }

        public async Task<User> LogIn(User user)
        {
            return await repository.LogIn(user);
        }


}

