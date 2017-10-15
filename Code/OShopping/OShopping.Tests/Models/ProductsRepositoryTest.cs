using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShopping;
using OShopping.Models;
using OShopping.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OShopping.Tests.Models
{
    [TestClass]
    public class ProductsRepositoryTest
    {
       

        [TestMethod]
        public void AddProducts()
        {
            ProductsRepository products = new ProductsRepository(" ");
            var productsList = GetProduts();
            var result = true;
            foreach (var item in productsList)
            {
                if (products.AddProduct(item) == null) result = false;
                
            }

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// For test purpose, call it just to insert some products
        /// </summary>
        private List<Product> GetProduts()
        {
            var productsList = new List<Product>()
            {
                new Product() { Category= ProductCategory.Informatic, Name="Computer", Price=101.99},
                new Product() { Category= ProductCategory.Home, Name="Table", Price=54.99},
                new Product() { Category= ProductCategory.Home, Name="Bed", Price=124.99},
                new Product() { Category= ProductCategory.Informatic, Name="RAM", Price=54.99},
                new Product() { Category= ProductCategory.Informatic, Name="CPU", Price=254.55},
                new Product() { Category= ProductCategory.Home, Name="Gas stove", Price=54.99},
                new Product() { Category= ProductCategory.Home, Name="Microwave", Price=54.99},
                new Product() { Category= ProductCategory.Home, Name="Washing machine", Price=54.99},
                new Product() { Category= ProductCategory.Sport, Name="Volley Ball", Price=54.99},
                new Product() { Category= ProductCategory.Sport, Name="Adidas Shoes", Price=54.99},
                new Product() { Category= ProductCategory.Sport, Name="Football shirt", Price=54.99},
                new Product() { Category= ProductCategory.Informatic, Name="Samsung Table", Price=54.99}
            };
            return productsList;
        }
    }
}
