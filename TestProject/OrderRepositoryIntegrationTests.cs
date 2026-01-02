using Entities;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class OrderRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly UserContext _dbContext;
        private readonly OrderRepository _orderRepository;

        public OrderRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            // Setup Hook: אתחול הקונטקסט והרפוזיטורי מה-Fixture
            _dbContext = databaseFixture.Context;
            _orderRepository = new OrderRepository(_dbContext);

            // ניקוי טבלת הזמנות לפני כל טסט
            _dbContext.Orders.RemoveRange(_dbContext.Orders);
            _dbContext.SaveChanges();
        }

        [Fact] // Happy Path: הוספת הזמנה ושליפתה
        public async Task AddOrder_ValidOrder_SavesAndReturnsOrder()
        {
            // Arrange
            var newOrder = new Order { OrderDate = DateOnly.FromDateTime(DateTime.Now), OrderSum = 150 };

            // Act
            var result = await _orderRepository.AddOrder(newOrder);
            var savedOrder = await _dbContext.Orders.FindAsync(result.OrderId);

            // Assert
            Assert.NotNull(savedOrder);
            Assert.Equal(150, savedOrder.OrderSum);
        }

        [Fact] // Unhappy Path: חיפוש הזמנה שלא קיימת
        public async Task GetOrderById_NonExistentId_ReturnsNull()
        {
            // Act
            var result = await _orderRepository.GetOrderById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
