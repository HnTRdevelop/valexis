using Microsoft.AspNetCore.Mvc;
using valexis.Domain;
using valexis.Domain.Entities;

namespace valexis.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataManager dataManager;

        public ProductsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(string id)
        {
            if (id != default && id.Length == 36)
            {
                return View("Show", dataManager.Products.GetProduct(new Guid(id)));
            }
            return View(dataManager.Products.GetProducts());
        }
    }
}
