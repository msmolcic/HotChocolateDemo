namespace HotChocolateDemo
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseSqlite("Data Source=main.db"))
                .AddGraphQLServer()
                .AddQueryType(t => t.Name("Query"))
                    .AddType<BorrowerQueries>()
                    .AddType<LoanQueries>()
                .AddType<BorrowerType>()
                .AddType<LoanType>()
                .EnableRelaySupport()
                .AddDataLoader<BorrowerByIdDataLoader>()
                .AddDataLoader<LoanByIdDataLoader>()
                .AddProjections()
                .EnsureDatabaseIsCreated()
                .AddFileSystemQueryStorage("./StoredQueries")
                .UseAutomaticPersistedQueryPipeline();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
