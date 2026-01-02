using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class OrderRepositoryUnitTests : IDisposable
    {
        private readonly UserContext _context;
        private readonly OrderRepository _repository;

        public OrderRepositoryUnitTests()
        {
            // Setup Hook: יצירת בסיס נתונים ייחודי בזיכרון
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new UserContext(options);
            _repository = new OrderRepository(_context);
        }

        [Fact] // Happy Path
        public async Task GetOrderById_ExistingOrder_ReturnsCorrectOrder()
        {
            // Arrange: הכנסת נתונים ישירות ל-DB בזיכרון
            var order = new Order { OrderId = 10, OrderSum = 500 };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetOrderById(10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.OrderSum);
        }

        public void Dispose()
        {
            // Teardown Hook: ניקוי ה-Context בסיום הטסט
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
