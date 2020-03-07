using API.WebClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.WebClient.Clients
{
    public class SupplierHttpClient
    {
        private readonly HttpClient _httpClient;

        public SupplierHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<SuppliersContainer>> GeSuppliersAndProducts()
        {
            var response = await _httpClient.GetAsync(@"?query= 
            { suppliers 
                { 
                    id 
                    name 
                    address 
                    products  {
                        id
                        name
                        price
                    }
                } 
            }");
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<SuppliersContainer>>(stringResult);
        }
    }
}
