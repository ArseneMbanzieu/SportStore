using SportStore.Data.Interface;
using SportStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebClient.Controllers
{
    public class AdminController : Controller
    {
        private IRepoProduct repo;

        public AdminController(IRepoProduct _repo)
        {
            this.repo = _repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repo.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product product = repo.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repo.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }
    }
}