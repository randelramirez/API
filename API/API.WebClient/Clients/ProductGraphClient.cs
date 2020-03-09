using System.Threading.Tasks;
using API.Core;
using API.WebClient.Models;
using GraphQL;
using GraphQL.Client;
using GraphQL.Common.Request;
using Newtonsoft.Json;

namespace API.WebClient.Clients
{
    public class ProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @" 
                query productQuery($productId: ID!)
                { product(id: $productId) 
                    { id name status price  
                      supplier { id name address }
                    }
                }",
                Variables = new { productId = id }
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<ProductViewModel>("product");
        }

        //public async Task<ProductReviewModel> AddReview(ProductReviewInputModel review)
        //{
        //    var query = new GraphQLRequest
        //    {
        //        Query = @" 
        //        mutation($review: reviewInput!)
        //        {
        //            createReview(review: $review)
        //            {
        //                id
        //            }
        //        }",
        //        Variables = new { review }
        //    };
        //    var response = await _client.PostAsync(query);
        //    return response.GetDataFieldAs<ProductReviewModel>("createReview");
        //}
    }
}
