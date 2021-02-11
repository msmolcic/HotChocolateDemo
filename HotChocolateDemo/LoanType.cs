namespace HotChocolateDemo
{
    using System.Linq;
    using HotChocolate;
    using HotChocolate.Resolvers;
    using HotChocolate.Types;
    using Microsoft.EntityFrameworkCore;

    public class LoanType : ObjectType<Loan>
    {
        protected override void Configure(IObjectTypeDescriptor<Loan> descriptor)
        {
            descriptor
                .Field(t => t.SharedId)
                .IsProjected();

            descriptor
                .ImplementsNode()
                .IdField(t => t.SharedId)
                .ResolveNode((context, id) => context
                    .DataLoader<LoanByIdDataLoader>()
                    .LoadAsync(id, context.RequestAborted));

            descriptor
                .Field(t => t.Borrowers)
                .ResolveWith<LoanResolvers>(t => t.GetBorrowers(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .UseProjection();
        }

        private class LoanResolvers
        {
            public IQueryable<Borrower> GetBorrowers(
                Loan loan,
                [ScopedService] ApplicationDbContext dbContext) =>
                dbContext.Borrowers
                    .AsNoTracking()
                    .Where(borrower => borrower.SharedId == loan.SharedId)
                    .OrderBy(e => e.Id);
        }
    }
}
