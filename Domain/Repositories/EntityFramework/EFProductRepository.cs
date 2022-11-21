using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valexis.Domain.Repositories.Abstract;
using valexis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace valexis.Domain.Repositories.EntityFramework
{
    public class EFProductRepository : IProductRepository 
    {
        private readonly AppDbContext context;
        public EFProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetProducts() 
        {
            return context.Products;
        } 

        public Product GetProduct(Guid id) 
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductByName(string name) 
        {
            return context.Products.FirstOrDefault(x => x.Name == name);
        }

        public void SaveProduct(Product product) 
        {
            if (product.Id == default)
                context.Entry(product).State = EntityState.Added;
            else
                context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            context.Products.Remove(GetProduct(id));
            context.SaveChanges();
        }
    }
}
