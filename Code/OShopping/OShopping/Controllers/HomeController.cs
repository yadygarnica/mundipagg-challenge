using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OShopping.Models;

namespace OShopping.Controllers
{
    public class HomeController : Controller
    {
        ProductsRepository products = new ProductsRepository(" ");
         
        /// <summary>
        /// Load the Contact view
        /// </summary>
        /// <returns>View Contact</returns>
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Load the Products view
        /// </summary>
        /// <returns>View Products</returns>
        public ActionResult Products()
        {
            var productsList = products.GetAllProducts();
            return View(productsList);
        }

        /// <summary>
        /// Load the Payment view
        /// </summary>
        /// <param name="id">Id of the selected product</param>
        /// <returns>View Payment</returns>
        public ActionResult BuyProduct(string id)
        {
            var product = products.GetProduct(id);
            ViewBag.ProductName = product.Name;
            ViewBag.ProductPrice = product.Price;
            return View("Payment");
        }             
        
    }
}