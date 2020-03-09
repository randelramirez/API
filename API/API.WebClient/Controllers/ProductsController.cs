using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.WebClient.Clients;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.WebClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductHttpClient httpClient;
        private readonly ProductGraphClient productGraphClient;

        public ProductsController(ProductHttpClient httpClient,
            ProductGraphClient productGraphClient)
        {
            this.httpClient = httpClient;
            this.productGraphClient = productGraphClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseModel = await httpClient.GetProducts();
            responseModel.ThrowErrors();
            return View(responseModel.Data.Products);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            var product = await productGraphClient.GetProduct(productId);

            //return View(product);
            //return new JsonResult(product);
            return new JsonResult(new
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Status = product.Status.ToString(),
                Supplier = new { Id = product.Supplier.Id, Name = product.Supplier.Name, Address = product.Supplier.Address }
            });
        }
    }
}