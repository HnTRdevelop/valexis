using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valexis.Domain.Repositories.Abstract;
using valexis.Domain.Entities;

namespace valexis.Domain
{
    public class DataManager
    {
        public IProductRepository Products { get; set; }
        
        public DataManager(IProductRepository productsRepository) 
        {
            Products = productsRepository;
        }
    }
}
