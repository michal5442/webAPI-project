using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System.Text.Json;
using System.Threading.Tasks;
namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        UserContext _userContext;
        public OrderRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _userContext.Orders.FindAsync(id);
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _userContext.Orders.AddAsync(order);
            await _userContext.SaveChangesAsync();
            return order;
        }

    }
}
