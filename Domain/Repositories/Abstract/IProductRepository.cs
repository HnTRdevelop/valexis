using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valexis.Domain.Entities;

namespace valexis.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProduct(Guid id);
        Product GetProductByName(string name);
        void SaveProduct(Product entity);
        void DeleteProduct(Guid id);
    }
}
