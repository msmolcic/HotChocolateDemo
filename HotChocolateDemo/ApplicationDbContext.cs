namespace HotChocolateDemo
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasData(
                    new Borrower() { Id = 1, SharedId = 1, Name = "Adam" },
                    new Borrower() { Id = 2, SharedId = 1, Name = "Mike" },
                    new Borrower() { Id = 3, SharedId = 2, Name = "Luke" },
                    new Borrower() { Id = 4, SharedId = 2, Name = "Sean" }
                );
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasData(
                    new Loan() { Id = 1, SharedId = 1, Amount = 100 },
                    new Loan() { Id = 2, SharedId = 1, Amount = 150 },
                    new Loan() { Id = 3, SharedId = 2, Amount = 200 },
                    new Loan() { Id = 4, SharedId = 2, Amount = 220 },
                    new Loan() { Id = 5, SharedId = 2, Amount = 270 }
                );
            });
        }

        public DbSet<Borrower> Borrowers { get; set; } = default!;
        public DbSet<Loan> Loans { get; set; } = default!;
    }
}
