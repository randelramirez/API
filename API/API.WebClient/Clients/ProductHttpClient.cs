using System.Net.Http;
using System.Threading.Tasks;
using API.WebClient.Models;
using Newtonsoft.Json;

namespace API.WebClient.Clients
{
    public class ProductHttpClient
    {
        private readonly HttpClient _httpClient;

        public ProductHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<ProductsContainer>> GetProducts()
        {
            var response = await _httpClient.GetAsync(@"?query= 
            { products 
                { 
                    id 
                    name 
                    price 
                    supplier  {
                        id
                        name
                        address
                    }
                } 
            }");
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ProductsContainer>>(stringResult);
        }
    }
}
