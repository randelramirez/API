using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.DataStore;
using API.DataStore.Extensions;
using API.GraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment environment;

        // inject and get IConfiguration & IWebHostEnvironment  from DI
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // ApiDataContext, for migration
            var apiDataContextAssembly = typeof(ApiDataContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApiDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("API_DataContext"),
                    sql => sql.MigrationsAssembly(apiDataContextAssembly));


            });

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ProductService>();
            services.AddScoped<SupplierService>();

            services.AddScoped<ProductsGraphQLSchema>();
            // workaround for threading issues in DbContext, might no longer be n
            services.AddScoped<IDocumentExecuter, EfDocumentExecuter>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = environment.IsDevelopment();
            })

            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddUserContextBuilder(context => context.User) // so we can access claims on query resolvers
            .AddDataLoader();

            //needed for .NET CORE 3.X
            // might not be needed in newer version of graphql-dotnet
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ApiDataContext dataContext /*we added the DataContext here to seed the database and development purposes*/)
        {
            app.UseGraphQL<ProductsGraphQLSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQLServer(new GraphiQLOptions()); // graphiql

            dataContext.SeedData();


        }
    }
}
