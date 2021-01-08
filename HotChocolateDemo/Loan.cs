namespace HotChocolateDemo
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Loan
    {
        public int Id { get; set; }
        public int SharedId { get; set; }
        public decimal Amount { get; set; }

        [NotMapped]
        public List<Borrower> Borrowers { get; set; }
            = new List<Borrower>();
    }
}
