using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.WebClient.Clients;
using Microsoft.AspNetCore.Mvc;

namespace API.WebClient.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierHttpClient httpClient;
        private readonly SupplierGraphClient supplierGraphClient;

        public SuppliersController(SupplierHttpClient httpClient,
            SupplierGraphClient supplierGraphClient)
        {
            this.httpClient = httpClient;
            this.supplierGraphClient = supplierGraphClient;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var responseModel = await httpClient.GeSuppliersAndProducts();
            responseModel.ThrowErrors();
            //return View(responseModel.Data.Suppliers);
            return new JsonResult(responseModel);
        }

        public async Task<IActionResult> SupplierDetail(int supplierId)
        {
            var supplier = await supplierGraphClient.GetSupplier(supplierId);
            return new JsonResult(supplier);
        }
    }
}