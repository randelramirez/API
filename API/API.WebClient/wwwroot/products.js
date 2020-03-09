const apolloClient = new Apollo.lib.ApolloClient({
    networkInterface: Apollo.lib.createNetworkInterface({
        uri: 'https://localhost:44360/graphql'
    })
});

function renderProducts(supplierId) {

    const query = Apollo.gql`
    query productsForSupplier($id: ID!) 
    {

        supplier(id: $id) {
            products {
                id
                name
                price
                status
            }
        }  
    }
    `;

    apolloClient
        .query({
            query: query,
            // the variable name must match the variable specified in ProductsGraphQLQuery
            variables: { id: supplierId }
        }).then(result => {
            const div = document.getElementById("products");
            result.data.supplier.products.forEach(product => {
                div.innerHTML += `            
                    <div class="row">
                        <div class="col-12"><h5>${product.id}</h5></div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-12">${product.name}</div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-12">${product.price}</div>
                    </div>
                     <div class="row mb-2">
                        <div class="col-12">${product.status}</div>
                    </div>`

                    ;
            });
        });
}