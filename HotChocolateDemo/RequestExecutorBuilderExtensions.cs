namespace HotChocolateDemo
{
    using HotChocolate.Execution.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ImportRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder EnsureDatabaseIsCreated(
            this IRequestExecutorBuilder builder) =>
            builder.ConfigureSchemaAsync(async (services, builder, cancellationToken) =>
            {
                IDbContextFactory<ApplicationDbContext> factory =
                    services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();

                using (ApplicationDbContext dbContext = factory.CreateDbContext())
                {
                    await dbContext.Database.EnsureCreatedAsync(cancellationToken);
                }
            });
    }
}
