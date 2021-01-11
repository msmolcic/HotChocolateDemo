namespace HotChocolateDemo
{
    using System.Linq;
    using HotChocolate;
    using HotChocolate.Resolvers;
    using HotChocolate.Types;
    using Microsoft.EntityFrameworkCore;

    public class BorrowerType : ObjectType<Borrower>
    {
        protected override void Configure(IObjectTypeDescriptor<Borrower> descriptor)
        {
            descriptor
                .Field(t => t.SharedId)
                .IsProjected();

            descriptor
                .ImplementsNode()
                .IdField(t => t.SharedId)
                .ResolveNode((context, id) => context
                    .DataLoader<BorrowerByIdDataLoader>()
                    .LoadAsync(id, context.RequestAborted));

            descriptor
                .Field(t => t.Loans)
                .ResolveWith<LoanResolvers>(t => t.GetLoans(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .UseOffsetPaging<NonNullType<LoanType>>()
                .Name("loans");
        }

        private class LoanResolvers
        {
            public IQueryable<Loan> GetLoans(
                Borrower borrower,
                [ScopedService] ApplicationDbContext dbContext) =>
                dbContext.Loans
                    .AsNoTracking()
                    .Where(loan => loan.SharedId == borrower.SharedId)
                    .OrderBy(e => e.Id);
        }
    }
}
