using Microsoft.AspNetCore.Mvc;
using valexis.Domain;
using valexis.Domain.Entities;
using valexis.Service;

namespace valexis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Products.GetProducts());
        }
    }
}
