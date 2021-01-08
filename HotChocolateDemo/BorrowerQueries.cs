namespace HotChocolateDemo
{
    using System.Linq;
    using HotChocolate;
    using HotChocolate.Types;
    using Microsoft.EntityFrameworkCore;

    [ExtendObjectType(Name = "Query")]
    public class BorrowerQueries
    {
        [UseApplicationDbContext]
        [UseOffsetPaging(typeof(NonNullType<BorrowerType>))]
        public IQueryable<Borrower> GetBorrowers(
            [ScopedService] ApplicationDbContext context) =>
            context.Borrowers.AsNoTracking().OrderBy(e => e.Id);
    }
}
