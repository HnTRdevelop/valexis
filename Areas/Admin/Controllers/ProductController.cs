using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using valexis.Domain;
using valexis.Domain.Entities;
using valexis.Service;

namespace valexis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProductController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Product() : dataManager.Products.GetProduct(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Product model, List<IFormFile> images, List<string> categoriesList)
        {
            if (ModelState.IsValid)
            {
                string cat = "";
                for(int i = 0; i < categoriesList.Count; i++) 
                {
                    cat += categoriesList[i];
                }
                model.Category = cat;

                if (images.Count > 0)
                {
                    model.ImageLink = "";
                    foreach (IFormFile img in images) {
                        model.ImageLink += img.FileName + "#@#";

                        var filePath = Path.Combine(hostingEnvironment.WebRootPath, "images/products/", img.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            img.CopyTo(stream);
                        }
                    }
                    model.ImageLink = model.ImageLink.Remove(model.ImageLink.Length - 3);
                }

                dataManager.Products.SaveProduct(model);
                return RedirectToAction("", "");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id) 
        {
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction("", "");
        }
    }
}
