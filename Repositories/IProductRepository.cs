using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page);
    }
}