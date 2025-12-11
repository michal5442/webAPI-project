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
    public class CategoryRepository : ICategoryRepository
    {
        UserContext _userContext;
        public CategoryRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _userContext.Categories.ToListAsync();
        }
    }
}
