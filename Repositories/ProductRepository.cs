using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        UserContext _userContext;
        public ProductRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<List<Product>> GetProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            return await _userContext.Products.ToListAsync();
        }
    }
}
