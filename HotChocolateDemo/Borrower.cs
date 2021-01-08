namespace HotChocolateDemo
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Borrower
    {
        public int Id { get; set; }
        public int SharedId { get; set; }
        public string Name { get; set; } = default!;

        [NotMapped]
        public List<Loan> Loans { get; set; }
            = new List<Loan>();
    }
}
