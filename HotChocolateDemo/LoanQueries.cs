namespace HotChocolateDemo
{
    using System.Linq;
    using HotChocolate;
    using HotChocolate.Types;
    using Microsoft.EntityFrameworkCore;

    [ExtendObjectType(Name = "Query")]
    public class LoanQueries
    {
        [UseApplicationDbContext]
        [UseOffsetPaging(typeof(NonNullType<LoanType>))]
        public IQueryable<Loan> GetLoans(
            [ScopedService] ApplicationDbContext context) =>
            context.Loans.AsNoTracking().OrderBy(e => e.Id);
    }
}
