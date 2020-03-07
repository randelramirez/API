using API.Core;
using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebClient.Clients
{
    public class SupplierGraphClient
    {
        private readonly GraphQLClient client;

        public SupplierGraphClient(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @" 
                query supplierQuery($supplierId: ID!)
                { supplier(id: $supplierId) 
                    { id name address  
                      products { id name price }
                    }
                }",
                Variables = new { supplierId = id }
            };
            var response = await client.PostAsync(query);
            return response.GetDataFieldAs<Supplier>("supplier");
        }
    }
}
