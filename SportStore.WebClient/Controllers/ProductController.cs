using SportStore.Data.Interface;
using SportStore.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebClient.Controllers
{
    public class ProductController : Controller
    {
        private IRepoProduct repository;
        public int pageSize = 4; // I want four product per page
        public ProductController( IRepoProduct repoProduct)
        {
            this.repository = repoProduct;
        }
        // GET: Product
       public ViewResult List(string category, int page = 1 )

        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category)
                                              .OrderBy(p => p.ProductID)
                                              .Skip((page - 1) * pageSize)
                                              .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                
                    repository.Products
                              .Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
                
            };

            return View(model);
           
            //return View(repository.Products.OrderBy(p => p.ProductID).Skip((page -1)* pageSize).Take(pageSize));
        }
    }
}